namespace Interfaces
{
    public interface IServiceLocator
    {
        public static IServiceLocator Global { get; protected set; }

        public void MakeGlobal();

        public void Register(IService service);
        public void Unregister(IService service);
        public T GetService<T>();
    }
}