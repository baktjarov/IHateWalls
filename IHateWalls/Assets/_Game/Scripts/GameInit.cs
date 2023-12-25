using GameStates;
using Interfaces;
using Services;
using System.Collections.Generic;
using UnityEngine;

namespace GameCore
{
    public class GameInit : MonoBehaviour
    {
        private IServiceLocator _serviceLocator;
        private IGameStateManager _gameStateManager;

        [SerializeField] private List<ScriptableObject> _scriptableObjectServices = new();

        private void OnValidate()
        {
            foreach (var scriptableObject in _scriptableObjectServices)
            {
                if (scriptableObject is IService == false)
                {
                    Debug.LogError(" is not an IService");
                }
            }
        }

        private void Start()
        {
            InitGame();

            DontDestroyOnLoad(gameObject);
        }

        private void Update()
        {
            _gameStateManager.Update();
        }

        [SerializeField] private CoroutineRunner _coroutineRunner;
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

            _serviceLocator.Register(_coroutineRunner);

            _gameStateManager = new GameStateManagner();
            _gameStateManager.ChangeState(new MainMenuState(_gameStateManager));
        }
    }
}