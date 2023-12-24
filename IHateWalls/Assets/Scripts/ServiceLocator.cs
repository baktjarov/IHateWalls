using Interfaces;
using System;
using System.Collections.Generic;

namespace GameCore
{
    public class ServiceLocator : IServiceLocator
    {
        // Словарь для хранения зарегистрированных сервисов по их типам
        private Dictionary<Type, IService> _services = new();

        // Метод для установки текущего экземпляра ServiceLocator в глобальный
        public void MakeGlobal()
        {
            IServiceLocator.Global = this;
        }

        // Метод для регистрации сервиса
        public void Register(IService service)
        {
            Type serviceType = service.GetType();

            // Проверка наличия типа сервиса уже в словаре
            if (_services.ContainsKey(serviceType))
            {
                // Если существует, обновляем сервис
                _services[serviceType] = service;
            }
            else
            {
                // Если не существует, добавляем сервис в словарь
                _services.Add(serviceType, service);
            }
        }

        // Метод для удаления зарегистрированного сервиса
        public void Unregister(IService service)
        {
            Type serviceType = service.GetType();

            // Проверка наличия типа сервиса в словаре
            if (_services.ContainsKey(serviceType))
            {
                // Если существует, удаляем сервис из словаря
                _services.Remove(serviceType);
            }
        }

        // Метод для получения сервиса по его типу
        public T GetService<T>()
        {
            Type serviceType = typeof(T);

            // Проверка наличия типа сервиса в словаре
            if (_services.ContainsKey(serviceType))
            {
                // Возвращаем сервис типа T
                return (T)_services[serviceType];
            }

            // Возвращаем значение по умолчанию, если сервис не найден
            return default(T);
        }
    }
}
