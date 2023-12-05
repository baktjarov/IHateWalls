using Interfaces;

namespace GameCore
{
    public class GameStateManagner : IGameStateManager
    {
        public IGameState _currentGameState { get; private set; }

        public void ChangeState(IGameState state)
        {
            if (_currentGameState != null) { _currentGameState.Exit(); }

            _currentGameState = state;
            _currentGameState.Enter();
        }

        public void Update()
        {
            if(_currentGameState != null)
            {
                _currentGameState.Update();
            }
        }
    }
}