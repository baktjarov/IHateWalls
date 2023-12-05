using Interfaces;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameStates
{
    public class MainMenuState : IGameState
    {
        private IGameStateManager _gameStateManager;

        public MainMenuState(IGameStateManager gameStateManager)
        {
            _gameStateManager = gameStateManager;
        }

        public void Enter()
        {
            SceneManager.LoadSceneAsync("MainMenu");
        }

        public void Exit()
        {

        }

        public void Update()
        {
            Debug.Log("GG");

            if (Input.GetKeyDown(KeyCode.G))
            {
                _gameStateManager.ChangeState(new GameplayState(_gameStateManager));
            }
        }
    }
}