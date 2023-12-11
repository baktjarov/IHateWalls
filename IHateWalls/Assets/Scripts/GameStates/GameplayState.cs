using Interfaces;
using System.Threading.Tasks;
using UI.Views;
using UnityEngine.SceneManagement;
using Walls;

namespace GameStates
{
    public class GameplayState : IGameState
    {
        private GameplayView _gameplayView;
        private WinView _winView;
        private WallHolder _wallHolder;
        private IGameStateManager _gameStateManager;

        public GameplayState(IGameStateManager gameStateManager)
        {
            _gameStateManager = gameStateManager;
        }

        public async void Enter()
        {
            var handle = SceneManager.LoadSceneAsync("Gameplay");
            while (handle.isDone == false) { await Task.Delay(500); }

            _gameplayView = UnityEngine.Object.FindAnyObjectByType<GameplayView>(UnityEngine.FindObjectsInactive.Include);
            _winView = UnityEngine.Object.FindAnyObjectByType<WinView>(UnityEngine.FindObjectsInactive.Include);

            _wallHolder = UnityEngine.Object.FindObjectOfType<WallHolder>(true);

            _gameplayView.Enable();

            _winView.onReplayButtonClicked += Replay;
            _winView.onMainMenuButtonClicked += GoToMainMenu;
        }

        public void Exit()
        {
            _winView.onReplayButtonClicked -= Replay;
            _winView.onMainMenuButtonClicked -= GoToMainMenu;
        }

        public void Update()
        {
            if (_gameplayView != null)
            {
                _gameplayView.Enable();
                _gameplayView?.SetProgress(_wallHolder.destructPercentage, _wallHolder.wallPieces.Count);
            }
        }

        private void Replay()
        {
            _gameStateManager.ChangeState(new GameplayState(_gameStateManager));
        }

        private void GoToMainMenu()
        {
            _gameStateManager.ChangeState(new MainMenuState(_gameStateManager));
        }
    }
}