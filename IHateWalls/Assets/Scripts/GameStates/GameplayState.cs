using Interfaces;
using System.Collections;
using System.Collections.Generic;
using UI.Views;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameStates
{
    public class GameplayState : IGameState
    {
        private GameplayView gameplayView;

        private IGameStateManager _gameStateManager;

        public GameplayState(IGameStateManager gameStateManager) 
        {
            _gameStateManager = gameStateManager;
        }

        public void Enter()
        {
            SceneManager.LoadSceneAsync("Gameplay");
        }

        public void Exit()
        {

        }

        public void Update()
        {

            Debug.Log("MM");


            if (Input.GetKeyDown(KeyCode.M))
            {
                _gameStateManager.ChangeState(new MainMenuState(_gameStateManager));
            }
        }
    }
}