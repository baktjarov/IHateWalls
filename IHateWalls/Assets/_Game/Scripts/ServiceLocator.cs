using Interfaces;
using System;
using System.Collections.Generic;

namespace GameCore
{
    public class ServiceLocator : IServiceLocator
    {
        private Dictionary<Type, IService> _services = new();

        public void MakeGlobal()
        {
            IServiceLocator.Global = this;
        }

        public void Register(IService service)
        {
            Type serviceType = service.GetType();

            if (_services.ContainsKey(serviceType) == true)
            {
                _services[serviceType] = service;
            }
            else
            {
                _services.Add(serviceType, service);
            }
        }

        public void Unregister(IService service)
        {
            Type serviceType = service.GetType();

            if (_services.ContainsKey(serviceType) == true)
            {
                _services.Remove(serviceType);
            }
        }

        public T GetService<T>()
        {
            Type serviceType = typeof(T);

            if (_services.ContainsKey(serviceType) == true)
            {
                return (T)_services[serviceType];
            }

            return default(T);
        }

        public bool IsTheSame<T>(T firstObject, T secondsObject) where T : IService
        {
            Type objectType = typeof(T);
            Type firstObjectType = firstObject.GetType();

            return firstObject.Equals(secondsObject);
        }
    }
}