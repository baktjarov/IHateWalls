using Interfaces;

namespace GameCore
{
    public class GameStateManagner : IGameStateManager
    {
        // Публичное свойство _currentGameState типа IGameState с доступом только для чтения (private set)
        public IGameState _currentGameState { get; private set; }

        // Метод ChangeState, принимающий объект типа IGameState
        public void ChangeState(IGameState state)
        {
            // Если _currentGameState не равен null, вызывается метод Exit()
            if (_currentGameState != null)
            {
                _currentGameState.Exit();
            }

            // Устанавливается новое значение _currentGameState
            _currentGameState = state;

            // Вызывается метод Enter() для нового состояния
            _currentGameState.Enter();
        }

        // Метод Update вызывается каждый кадр
        public void Update()
        {
            // Если _currentGameState не равен null
            if (_currentGameState != null)
            {
                // Вызывается метод Update() для текущего состояния
                _currentGameState.Update();
            }
        }
    }
}