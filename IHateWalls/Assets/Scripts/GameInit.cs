using GameStates;
using Interfaces;
using UnityEngine;

namespace GameCore
{
    public class GameInit : MonoBehaviour
    {
        private IServiceLocator _serviceLocator;
        private IGameStateManager _gameStateManager;

        private void Start()
        {
            InitGame();

            DontDestroyOnLoad(gameObject);
        }

        private void Update()
        {
            _gameStateManager.Update();
        }

        private void InitGame()
        {
            _gameStateManager = new GameStateManagner();

            _gameStateManager.ChangeState(new MainMenuState(_gameStateManager));
        }
    }
}