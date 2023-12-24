using GameStates;
using Interfaces;
using System.Collections.Generic;
using UnityEngine;

namespace GameCore
{
    public class GameInit : MonoBehaviour
    {
        // Приватное поле для локатора сервисов
        private IServiceLocator _serviceLocator;
        // Приватное поле для менеджера игровых состояний
        private IGameStateManager _gameStateManager;
        // Список ScriptableObject для сервисов
        [SerializeField] private List<ScriptableObject> _scriptableObjectServices = new();

        // Метод Start вызывается при запуске
        private void Start()
        {
            // Инициализация игры
            InitGame();

            // Гарантирует сохранение GameObject между сценами
            DontDestroyOnLoad(gameObject);
        }

        // Метод Update вызывается каждый кадр
        private void Update()
        {
            // Обновление менеджера игровых состояний
            _gameStateManager.Update();
        }

        // Метод для инициализации игры
        private void InitGame()
        {
            // Создание нового локатора сервисов и его установка как глобального
            _serviceLocator = new ServiceLocator();
            _serviceLocator.MakeGlobal();

            // Проход по списку ScriptableObject
            foreach (ScriptableObject scriptableObject in _scriptableObjectServices)
            {
                // Проверка, реализует ли ScriptableObject интерфейс IService
                if (scriptableObject is IService)
                {
                    // Преобразование ScriptableObject к типу IService
                    IService convertedService = (IService)scriptableObject;

                    // Регистрация сервиса в локаторе сервисов
                    _serviceLocator.Register(convertedService);
                }
            }

            // Создание нового менеджера игровых состояний
            _gameStateManager = new GameStateManagner();

            // Изменение начального игрового состояния на MainMenuState
            _gameStateManager.ChangeState(new MainMenuState(_gameStateManager));
        }
    }
}