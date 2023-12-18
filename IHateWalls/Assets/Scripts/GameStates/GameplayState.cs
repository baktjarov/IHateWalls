using Interfaces;
using SO;
using System.Threading.Tasks;
using UI.Views;
using UnityEngine;
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
        private IServiceLocator _serviceLocator;
        private ListOfWalls _listOfWalls;

        public GameplayState(IGameStateManager gameStateManager)
        {
            _gameStateManager = gameStateManager;
        }

        public async void Enter()
        {
            var handle = SceneManager.LoadSceneAsync("Gameplay");
            while (handle.isDone == false) { await Task.Delay(500); }

            if (SetupDependencies() == true)
            {
                SetupUI();
                AddWall();
            }
            else
            {
                GoToMainMenu();
            }
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

        private bool SetupDependencies()
        {
            _serviceLocator = IServiceLocator.Global;

            if (_serviceLocator == null)
            {
                Debug.LogError("Service Locator is null");
                return false;
            }

            _listOfWalls = _serviceLocator.GetService<ListOfWalls>();

            return true;
        }

        private void SetupUI()
        {
            _gameplayView = UnityEngine.Object.FindAnyObjectByType<GameplayView>(UnityEngine.FindObjectsInactive.Include);
            _winView = UnityEngine.Object.FindAnyObjectByType<WinView>(UnityEngine.FindObjectsInactive.Include);

            _gameplayView.Enable();

            _winView.onReplayButtonClicked += Replay;
            _winView.onMainMenuButtonClicked += GoToMainMenu;
        }

        private void AddWall()
        {
            WallHolder wallFromList = _listOfWalls.GetWall();

            _wallHolder = Object.Instantiate(wallFromList);
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