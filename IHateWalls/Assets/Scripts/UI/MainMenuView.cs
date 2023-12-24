using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Views
{
    public class MainMenuView : ViewBase
    {
        // Действие, которое будет вызываться при нажатии кнопки "Play"
        public Action onPlayButtonClicked;

        // Кнопка "Play"
        [SerializeField] private Button _playButton;
        // Кнопка "Quit"
        [SerializeField] private Button _quitButton;

        // Переопределение метода включения представления
        public override void Enable()
        {
            // Вызов метода базового класса
            base.Enable();

            // Добавление слушателя на нажатие кнопки "Play"
            _playButton.onClick.AddListener(OnPlayButtonClicked);
        }

        // Переопределение метода выключения представления
        public override void Disable()
        {
            // Вызов метода базового класса
            base.Disable();

            // Удаление слушателя события нажатия кнопки "Play"
            _playButton.onClick.RemoveListener(OnPlayButtonClicked);
        }

        // Метод вызывается при нажатии кнопки "Play"
        private void OnPlayButtonClicked()
        {
            // Вызов действия при нажатии кнопки "Play", если оно существует
            onPlayButtonClicked?.Invoke();
        }
    }
}

