using Interfaces;
using SO;
using System.Threading.Tasks;
using UI.Views;
using UnityEngine;
using UnityEngine.SceneManagement;
using Walls;

namespace GameStates
{
    public class GameplayState : IGameState
    {
        // Перечисление состояний игрового процесса
        private enum GameplayStates
        {
            // Игровой процесс
            gameplay,
            // Победа
            win
        }
        // Представление игрового процесса
        private GameplayView _gameplayView;
        // Представление победы
        private WinView _winView;
        // Объект для хранения стены
        private WallHolder _wallHolder;
        // Менеджер состояний игры
        private IGameStateManager _gameStateManager;
        // Локатор сервисов
        private IServiceLocator _serviceLocator;
        // Список стен
        private ListOfWalls _listOfWalls;
        // Список представлений
        private ListOfViews _listOfViews;
        // Настройки игры
        private GameSettings _gameSettings;
        // Текущее состояние игрового процесса
        private GameplayStates _gameplayStates;
        // Конструктор класса GameplayState
        public GameplayState(IGameStateManager gameStateManager)
        {
            // Инициализация менеджера состояний игры
            _gameStateManager = gameStateManager;
        }

        // Метод входа в состояние игрового процесса
        public async void Enter()
        {
            // Загрузка сцены Gameplay
            SceneManager.LoadScene("Gameplay");
            
            // Проверка и установка зависимостей
            if (SetupDependencies() == true)
            {
                // Установка состояния игрового процесса
                _gameplayStates = GameplayStates.gameplay;

                // Настройка пользовательского интерфейса
                SetupUI();
                // Добавление стены
                AddWall();
            }
            else
            {
                // Переход в главное меню в случае ошибки
                GoToMainMenu();
            }
        }

        // Метод выхода из состояния игрового процесса
        public void Exit()
        {
            // Отписка от события нажатия кнопки "Replay"
            _winView.onReplayButtonClicked -= Replay;
            // Отписка от события перехода в главное меню
            _winView.onMainMenuButtonClicked -= GoToMainMenu;
        }

        // Метод обновления состояния
        public void Update()
        {
            // Если представление игрового процесса не равно null
            if (_gameplayView != null)
            {
                // Проверка состояния игрового процесса 
                switch (_gameplayStates)
                {
                    // Если текущее состояние - игровой процесс
                    case GameplayStates.gameplay:
                        {
                            // Обработка состояния игрового процесса
                            HandleGameplayState();
                            break;
                        }
                    // Если текущее состояние - победа
                    case GameplayStates.win:
                        {
                            // Обработка состояния победы
                            HandleWinState();
                            break;
                        }
                }
            }
        }

        // Метод обработки состояния игрового процесса
        private void HandleGameplayState()
        {
            // Количество разрушенных частей стены
            float releasedPieces = (float)_wallHolder.destructProgress;
            // Процент разрушения стены
            float destructPercentage = (releasedPieces / _wallHolder.wallPieces.Count) * 100;

            // Установка прогресса в представлении игрового процесса
            _gameplayView?.SetProgress(destructPercentage, 100);

            // Если процент разрушения больше или равен установленному для победы
            if (destructPercentage >= _gameSettings.winPercentage)
            {
                // Установка следующей стены
                _listOfWalls.SetNextWall();

                // Отключение представления игрового процесса
                _gameplayView.Disable();
                // Установка состояния победы
                _gameplayStates = GameplayStates.win;
            }
        }

        // Метод обработки состояния победы
        private void HandleWinState()
        {
            // Если представление победы не активно в иерархии
            if (_winView.gameObject.activeInHierarchy == false)
            {
                // Включение представления победы
                _winView.Enable();
            }
        }

        // Метод установки зависимостей
        private bool SetupDependencies()
        {
            // Получение глобального локатора сервисов
            _serviceLocator = IServiceLocator.Global;

            // Если локатор сервисов null
            if (_serviceLocator == null)
            {
                // Вывод ошибки в консоль
                Debug.LogError("Service Locator is null");
                // Возврат false
                return false;
            }

            // Получение списка стен из локатора сервисов
            _listOfWalls = _serviceLocator.GetService<ListOfWalls>();
            // Получение списка представлений из локатора сервисов
            _listOfViews = _serviceLocator.GetService<ListOfViews>();
            // Получение настроек игры из локатора сервисов
            _gameSettings = _serviceLocator.GetService<GameSettings>();
            // Возврат true
            return true;
        }

        // Метод настройки пользовательского интерфейса
        private void SetupUI()
        {
            // Получение представления игрового процесса из списка
            if (_listOfViews.TryGetView<GameplayView>(out GameplayView gameplayViewFromList) == true)
            {
                // Создание экземпляра представления игрового процесса
                _gameplayView = Object.Instantiate(gameplayViewFromList);
            }

            // Получение представления победы из списка
            if (_listOfViews.TryGetView<WinView>(out WinView winViewFromList) == true)
            {
                // Создание экземпляра представления победы
                _winView = Object.Instantiate(winViewFromList);
            }

            // Включение представления игрового процесса
            _gameplayView.Enable();

            // Подписка на событие нажатия кнопки "Replay"
            _winView.onReplayButtonClicked += Replay;
            // Подписка на событие перехода в главное меню
            _winView.onMainMenuButtonClicked += GoToMainMenu;
        }

        // Метод добавления стены
        private void AddWall()
        {
            // Получение стены из списка
            WallHolder wallFromList = _listOfWalls.GetWall();
            // Создание экземпляра стены
            _wallHolder = Object.Instantiate(wallFromList);
        }

        // Метод перезапуска игрового процесса
        private void Replay()
        {
            // Смена состояния на GameplayState
            _gameStateManager.ChangeState(new GameStates.GameplayState(_gameStateManager));
        }

        // Метод перехода в главное меню
        private void GoToMainMenu()
        {
            // Смена состояния на MainMenuState
            _gameStateManager.ChangeState(new MainMenuState(_gameStateManager));
        }
    }
}