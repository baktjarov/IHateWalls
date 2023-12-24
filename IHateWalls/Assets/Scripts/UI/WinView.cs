using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Views
{
    public class WinView : ViewBase
    {
        // Действие, которое будет вызываться при нажатии кнопки "Replay"
        public Action onReplayButtonClicked;
        // Действие, которое будет вызываться при нажатии кнопки "Main Menu"
        public Action onMainMenuButtonClicked;

        // Кнопка "Replay"
        [SerializeField] private Button _replayButton;
        // Кнопка "Main Menu"
        [SerializeField] private Button _mainMenuButton;

        // Переопределение метода включения представления
        public override void Enable()
        {
            // Вызов метода базового класса
            base.Enable();

            // Добавление слушателя на нажатие кнопки "Replay"
            _replayButton.onClick.AddListener(OneReplayButtonClicked);
            // Добавление слушателя на нажатие кнопки "Main Menu"
            _mainMenuButton.onClick.AddListener(OneMainMenuButtonClicked);
        }

        // Переопределение метода выключения представления
        public override void Disable()
        {
            base.Disable(); // Вызов метода базового класса

            // Удаление слушателя события нажатия кнопки "Replay"
            _replayButton.onClick.RemoveListener(OneReplayButtonClicked);
            // Удаление слушателя события нажатия кнопки "Main Menu"
            _mainMenuButton.onClick.RemoveListener(OneMainMenuButtonClicked);
        }

        // Метод вызывается при нажатии кнопки "Replay"
        private void OneReplayButtonClicked()
        {
            // Вызов действия при нажатии кнопки "Replay", если оно существует
            onReplayButtonClicked?.Invoke();
        }

        // Метод вызывается при нажатии кнопки "Main Menu"
        private void OneMainMenuButtonClicked()
        {
            // Вызов действия при нажатии кнопки "Main Menu", если оно существует
            onMainMenuButtonClicked?.Invoke();
        }
    }
}
