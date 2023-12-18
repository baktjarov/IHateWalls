using GameStates;
using Interfaces;
using System.Collections.Generic;
using UnityEngine;

namespace GameCore
{
    public class GameInit : MonoBehaviour
    {
        private IServiceLocator _serviceLocator;
        private IGameStateManager _gameStateManager;

        [SerializeField] private List<ScriptableObject> _scriptableObjectServices = new();

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
            _serviceLocator = new ServiceLocator();
            _serviceLocator.MakeGlobal();

            foreach (ScriptableObject scriptableObject in _scriptableObjectServices)
            {
                if (scriptableObject is IService)
                {
                    IService convertedService = (IService)scriptableObject;
                    _serviceLocator.Register(convertedService);
                }
            }

            _gameStateManager = new GameStateManagner();
            _gameStateManager.ChangeState(new MainMenuState(_gameStateManager));
        }
    }
}