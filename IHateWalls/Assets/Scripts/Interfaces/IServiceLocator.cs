using System.Collections.Generic;

namespace Interfaces
{
    public interface IServiceLocator
    {
        public Dictionary<IService, object> _services { get; }

        public void Register<IService>(IService service);
        public void Unregister<IService>(IService service);
        public T GetService<T>() where T : IService;
    }
}