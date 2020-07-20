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
                Debug.WriteLine($"Registered {regType} for {intType}");
                if (withDecorators)
                {
                    var genericTypes = intType.GetGenericArguments();
                    var performanceDecoratorGeneric = typeof(QueryPerformanceDecorator<,>);
                    var constructedGeneric = performanceDecoratorGeneric.MakeGenericType(genericTypes);
                    serviceRegistry.Decorate(intType, constructedGeneric);
                    Debug.WriteLine($"Decorated {intType} for {constructedGeneric}");
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
