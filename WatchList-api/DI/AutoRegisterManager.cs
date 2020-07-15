using LightInject;
using System;
using System.Linq;

namespace WatchList_api
{
    public static class AutoRegisterManager
    {
        public static void AutoRegisterFromInterface(IServiceRegistry serviceRegistry, Type interfaceType)
        {
            if (!interfaceType.IsInterface) throw new InterfaceOnlyException();
            var registeredTypes = typeof(Startup)
               .Assembly
               .GetTypes()
               .Where(i => interfaceType.IsAssignableFrom(i));

            foreach (var regType in registeredTypes)
            {
                var interfaceTypes = regType.GetInterfaces();
                foreach (var intType in interfaceTypes)
                {
                    if (intType.Name == nameof(interfaceType)) continue;
                    serviceRegistry.Register(intType, regType);
                }
            }
        }
    }

    public class InterfaceOnlyException : Exception
    {

    }
}
