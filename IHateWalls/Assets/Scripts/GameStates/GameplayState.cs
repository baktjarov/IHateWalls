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
        private enum GameplayStates
        {
            gameplay,
            win
        }

        //UI
        private GameplayView _gameplayView;
        private WinView _winView;

        //Wall
        private WallHolder _wallHolder;

        //Managers
        private IGameStateManager _gameStateManager;
        private IServiceLocator _serviceLocator;

        //Dependencies
        private ListOfWalls _listOfWalls;
        private ListOfViews _listOfViews;
        private GameSettings _gameSettings;

        private GameplayStates _gameplayStates;

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
                _gameplayStates = GameplayStates.gameplay;

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
                switch (_gameplayStates)
                {
                    case GameplayStates.gameplay:
                        {
                            HandleGameplayState();
                            break;
                        }
                    case GameplayStates.win:
                        {
                            HandleWinState();
                            break;
                        }
                }
            }
        }

        private void HandleGameplayState()
        {
            float realeasedPieces = (float)_wallHolder.destructProgress;
            float destructPercentage = (realeasedPieces / _wallHolder.wallPieces.Count) * 100;

            _gameplayView?.SetProgress(destructPercentage, 100);

            if (destructPercentage >= _gameSettings.winPercentage)
            {
                _listOfWalls.SetNextWall();

                _gameplayView.Disable();
                _gameplayStates = GameplayStates.win;
            }
        }

        private void HandleWinState()
        {
            if (_winView.gameObject.activeInHierarchy == false)
            {
                _winView.Enable();
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
            _listOfViews = _serviceLocator.GetService<ListOfViews>();
            _gameSettings = _serviceLocator.GetService<GameSettings>();

            return true;
        }

        private void SetupUI()
        {
            if (_listOfViews.TryGetView<GameplayView>(out GameplayView gameplayViewFromList) == true)
            {
                _gameplayView = Object.Instantiate(gameplayViewFromList);
            }

            if (_listOfViews.TryGetView<WinView>(out WinView winViewFromList) == true)
            {
                _winView = Object.Instantiate(winViewFromList);
            }

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
            _gameStateManager.ChangeState(new GameStates.GameplayState(_gameStateManager));
        }

        private void GoToMainMenu()
        {
            _gameStateManager.ChangeState(new MainMenuState(_gameStateManager));
        }
    }
}