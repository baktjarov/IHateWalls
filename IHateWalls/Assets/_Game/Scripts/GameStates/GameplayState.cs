using Enviroments;
using Interfaces;
using Services;
using SO;
using System;
using System.Collections;
using UI.Views;
using UnityEngine;
using UnityEngine.SceneManagement;
using Walls;

using Object = UnityEngine.Object;

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
        private ListOfEnviroments _listOfEnviroments;
        private GameSettings _gameSettings;

        private GameplayStates _gameplayStates;

        public GameplayState(IGameStateManager gameStateManager)
        {
            _gameStateManager = gameStateManager;
        }

        private CoroutineRunner _coroutineRunner;
        public void Enter()
        {
            if (SetupDependencies() == true)
            {
                _coroutineRunner.StartCoroutine(SceneLoader.LoadScene("Gameplay", () =>
                {
                    _gameplayStates = GameplayStates.gameplay;

                    SetupUI();
                    AddWall();
                    AddEnviroment();
                }));

            }
            else
            {
                GoToMainMenu();
            }
        }

        public void Exit()
        {
            _winView.onNextButtonClicked -= Next;
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
            float releasedPieces = (float)_wallHolder.destructProgress;
            float dectructPercentage = (releasedPieces / _wallHolder.wallPieces.Count) * 100;

            _gameplayView?.SetProgress(dectructPercentage, 100);

            if (dectructPercentage >= _gameSettings.winPercentage)
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
            _listOfEnviroments = _serviceLocator.GetService<ListOfEnviroments>();
            _coroutineRunner = _serviceLocator.GetService<CoroutineRunner>();

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

            _winView.onNextButtonClicked += Next;
            _winView.onMainMenuButtonClicked += GoToMainMenu;
        }

        private void AddWall()
        {
            WallHolder wallFromList = _listOfWalls.GetWall();

            _wallHolder = Object.Instantiate(wallFromList);
        }

        private void AddEnviroment()
        {
            Enviroment enviroment = _listOfEnviroments.GetEnviroment();
            Object.Instantiate(enviroment);
        }

        private void Next()
        {
            _gameStateManager.ChangeState(new GameplayState(_gameStateManager));
        }

        private void GoToMainMenu()
        {
            _gameStateManager.ChangeState(new MainMenuState(_gameStateManager));
        }
    }
}