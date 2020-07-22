using LightInject;
using System;
using System.Diagnostics;
using System.Linq;
using WatchList_api.CQRS;

namespace WatchList_api
{
    public static class AutoRegisterManager
    {
        public static void AutoRegisterIQuery(IServiceRegistry serviceRegistry, bool withDecorators)
        {
            var registeredTypes = typeof(Startup)
               .Assembly
               .GetTypes()
               .Where(i => typeof(IAutoRegisterQuery).IsAssignableFrom(i));

            foreach (var regType in registeredTypes)
            {
                var intType = regType.GetInterfaces().Where(i => i != typeof(IAutoRegisterQuery)).SingleOrDefault();
                if (intType == null) continue;
                serviceRegistry.Register(intType, regType);
                if (withDecorators)
                {
                    var genericTypes = intType.GetGenericArguments();
                    var performanceDecoratorGeneric = typeof(QueryPerformanceDecorator<,>);
                    var errorLoggingDecoratorGeneric = typeof(ErrorLoggingDecorator<,>);
                    var constructedPerformanceGeneric = performanceDecoratorGeneric.MakeGenericType(genericTypes);
                    var constructedErrorLoggingGeneric = errorLoggingDecoratorGeneric.MakeGenericType(genericTypes);
                    serviceRegistry.Decorate(intType, constructedErrorLoggingGeneric);
                    serviceRegistry.Decorate(intType, constructedPerformanceGeneric);
                }
            }
        }

        public static void AutoRegisterICommand(IServiceRegistry serviceRegistry, bool withDecorators)
        {
            var registeredTypes = typeof(Startup)
               .Assembly
               .GetTypes()
               .Where(i => typeof(IAutoRegisterCommand).IsAssignableFrom(i));

            foreach (var regType in registeredTypes)
            {
                var intType = regType.GetInterfaces().Where(i => i != typeof(IAutoRegisterCommand)).SingleOrDefault();
                if (intType == null) continue;
                serviceRegistry.Register(intType, regType);
                Debug.WriteLine($"Registered {regType} for {intType}");
            }
        }
    }

    public class InterfaceOnlyException : Exception
    {

    }
}
