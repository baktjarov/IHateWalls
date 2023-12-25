using Interfaces;
using Services;
using System;
using System.Collections;
using System.Threading.Tasks;
using UI.Views;
using UnityEngine;
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

        private CoroutineRunner _coroutineRunner;
        public void Enter()
        {
            _coroutineRunner = IServiceLocator.Global.GetService<CoroutineRunner>();

            _coroutineRunner.StartCoroutine(SceneLoader.LoadScene("MainMenu", () =>
            {
                _mainMenuView = UnityEngine.Object.FindObjectOfType<MainMenuView>(true);
                _mainMenuView.Enable();

                _mainMenuView.onPlayButtonClicked += EnterGameplayState;
            }));
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