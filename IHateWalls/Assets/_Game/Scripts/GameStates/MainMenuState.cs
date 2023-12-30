using Interfaces;
using Services;
using SO;
using System;
using System.Collections;
using System.Threading.Tasks;
using UI.Views;
using UnityEngine;
using UnityEngine.SceneManagement;

using Object = UnityEngine.Object;

namespace GameStates
{
    public class MainMenuState : IGameState
    {
        private enum MainMenuStates
        {
            mainMenu,
            settings
        }

        //UI
        private MainMenuView _mainMenuView;
        private SettingsView _settingsView;

        //Managers
        private IGameStateManager _gameStateManager;
        private IServiceLocator _serviceLocator;

        //Dependencies
        private ListOfViews _listOfViews;

        private MainMenuStates _mainMenuStates;
        public MainMenuState(IGameStateManager gameStateManager)
        {
            _gameStateManager = gameStateManager;
        }

        private CoroutineRunner _coroutineRunner;
        public void Enter()
        {
            if (SetupDependencies() == true)
            {
                _coroutineRunner.StartCoroutine(SceneLoader.LoadScene("MainMenu", () =>
                {
                    _mainMenuStates = MainMenuStates.mainMenu;

                    SetupUI();
                }));
            }
        }

        public void Exit()
        {
            _mainMenuView.Disable();

            _mainMenuView.onPlayButtonClicked -= EnterGameplayState;
            _mainMenuView.onMainMenuSettingsButtonClicked -= EnterSettingsMenu;
            _settingsView.onBackButtonClicked -= GoToMainMenu;
        }

        public void Update()
        {
            if (_mainMenuView != null)
            {
                switch (_mainMenuStates)
                {
                    case MainMenuStates.mainMenu:
                        {
                            HandleMainMenuState();
                            break;
                        }
                    case MainMenuStates.settings:
                        {
                            HandleSettingsState();
                            break;
                        }
                }
            }
        }

        private void HandleMainMenuState()
        {
            if (_mainMenuView.gameObject.activeInHierarchy == false)
            {
                _mainMenuView.Enable();
                _settingsView.Disable();
            }
        }

        private void HandleSettingsState()
        {
            if (_settingsView.gameObject.activeInHierarchy == false)
            {
                _settingsView.Enable();
                _mainMenuView.Disable();

                _mainMenuStates = MainMenuStates.settings;
            }
        }

        private void SetupUI()
        {
            if (_listOfViews.TryGetView<SettingsView>(out SettingsView settingsViewFromList) == true)
            {
                _settingsView = Object.Instantiate(settingsViewFromList);
            }
            if (_listOfViews.TryGetView<MainMenuView>(out MainMenuView mainMenuViewFromList) == true)
            {
                _mainMenuView = Object.Instantiate(mainMenuViewFromList);
            }

            _mainMenuView.Enable();

            _mainMenuView.onPlayButtonClicked += EnterGameplayState;
            _mainMenuView.onMainMenuSettingsButtonClicked += EnterSettingsMenu;
            _settingsView.onBackButtonClicked += GoToMainMenu;
        }

        private bool SetupDependencies()
        {
            _serviceLocator = IServiceLocator.Global;

            if (_serviceLocator == null)
            {
                Debug.LogError("Service Locator is null");
                return false;
            }

            _listOfViews = _serviceLocator.GetService<ListOfViews>();
            _coroutineRunner = _serviceLocator.GetService<CoroutineRunner>();

            return true;
        }

        private void EnterGameplayState()
        {
            _gameStateManager.ChangeState(new GameplayState(_gameStateManager));
        }

        private void EnterSettingsMenu()
        {
            HandleSettingsState();
        }

        private void GoToMainMenu()
        {
            _mainMenuStates = MainMenuStates.mainMenu;
            HandleMainMenuState();
        }
    }
}