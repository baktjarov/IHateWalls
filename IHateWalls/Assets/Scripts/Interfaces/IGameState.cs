namespace Interfaces
{
    public interface IGameState
    {
        // Метод для входа в состояние
        public void Enter();
        // Метод для выхода из состояния
        public void Exit();
        // Метод для обновления состояния
        public void Update();
    }
}