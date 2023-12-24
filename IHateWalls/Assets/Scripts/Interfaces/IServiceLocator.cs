namespace Interfaces
{
    public interface IServiceLocator
    {
        // Статическое свойство для глобального экземпляра
        public static IServiceLocator Global { get; protected set; }

        // Метод для создания глобального экземпляра
        public void MakeGlobal();

        // Метод для регистрации сервиса
        public void Register(IService service);
        // Метод для удаления сервиса
        public void Unregister(IService service);
        // Метод для получения сервиса по типу
        public T GetService<T>();
    }
}