namespace Interfaces
{
    public interface IGameStateManager
    {
        public IGameState _currentGameState { get; }

        public void ChangeState(IGameState state);
        public void Update();
    }
}