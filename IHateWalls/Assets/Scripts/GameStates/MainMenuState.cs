using Interfaces;
using System.Threading.Tasks;
using UI.Views;
using UnityEngine.SceneManagement;

namespace GameStates
{
    public class MainMenuState : IGameState
    {
        // Объявление переменной для представления главного меню
        private MainMenuView _mainMenuView;
        // Объявление переменной для менеджера состояний игры
        private IGameStateManager _gameStateManager;

        // Конструктор класса MainMenuState с параметром gameStateManager типа IGameStateManager
        public MainMenuState(IGameStateManager gameStateManager)
        {
            // Инициализация переменной менеджера состояний игры
            _gameStateManager = gameStateManager;
        }

        // Метод входа в состояние главного меню
        public async void Enter()
        {
            // Асинхронная загрузка сцены "MainMenu"
            var handle = SceneManager.LoadSceneAsync("MainMenu");
            // Ожидание завершения загрузки сцены
            while (handle.isDone == false) { await Task.Delay(500); }

            // Поиск представления главного меню
            _mainMenuView = UnityEngine.Object.FindAnyObjectByType<MainMenuView>(UnityEngine.FindObjectsInactive.Include);
            // Включение представления главного меню
            _mainMenuView.Enable();
            // Подписка на событие нажатия кнопки "Play"
            _mainMenuView.onPlayButtonClicked += EnterGameplayState;
        }

        // Метод выхода из состояния главного меню
        public void Exit()
        {
            // Отключение представления главного меню
            _mainMenuView.Disable();
            // Отписка от события нажатия кнопки "Play"
            _mainMenuView.onPlayButtonClicked -= EnterGameplayState;
        }

        public void Update()
        {

        }

        // Метод для перехода в состояние игрового процесса
        private void EnterGameplayState()
        {
            // Изменение состояния на GameplayState
            _gameStateManager.ChangeState(new GameplayState(_gameStateManager));
        }
    }
}