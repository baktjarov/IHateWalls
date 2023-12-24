namespace Interfaces
{
    public interface IGameStateManager
    {
        // Свойство для текущего игрового состояния
        public IGameState _currentGameState { get; }

        // Метод для изменения состояния
        public void ChangeState(IGameState state);
        // Метод для обновления
        public void Update();
    }
}