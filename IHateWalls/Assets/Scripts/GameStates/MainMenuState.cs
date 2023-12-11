using Interfaces;
using System.Threading.Tasks;
using UI.Views;
using UnityEngine.SceneManagement;

namespace GameStates
{
    public class MainMenuState : IGameState
    {
        private MainMenuView _mainMenuView;
        private IGameStateManager _gameStateManager;

        public MainMenuState(IGameStateManager gameStateManager)
        {
            _gameStateManager = gameStateManager;
        }

        public async void Enter()
        {
            var handle = SceneManager.LoadSceneAsync("MainMenu");
            while (handle.isDone == false) { await Task.Delay(500); }

            _mainMenuView = UnityEngine.Object.FindAnyObjectByType<MainMenuView>(UnityEngine.FindObjectsInactive.Include);

            _mainMenuView.Enable();
            _mainMenuView.onPlayButtonClicked += EnterGameplayState;
        }

        public void Exit()
        {
            _mainMenuView.Disable();
            _mainMenuView.onPlayButtonClicked -= EnterGameplayState;
        }

        public void Update()
        {

        }

        private void EnterGameplayState()
        {
            _gameStateManager.ChangeState(new GameplayState(_gameStateManager));
        }
    }
}