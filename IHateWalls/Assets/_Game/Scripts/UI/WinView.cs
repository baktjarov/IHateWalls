using System;
using UnityEngine;
using UnityEngine.UI;
using Player;

namespace UI.Views
{
    public class WinView : ViewBase
    {
        public Action onNextButtonClicked;
        public Action onMainMenuButtonClicked;
        public Action onSettingsButtonClicked;

        [SerializeField] private Button _nextButton;
        [SerializeField] private Button _mainMenuButton;
        [SerializeField] private Button _settingsButton;
        [SerializeField] private PlayerController _playerController; // Ссылка на скрипт управления персонажем

        public override void Enable()
        {
            base.Enable();

            _nextButton.onClick.AddListener(OnNextButtonClicked);
            _mainMenuButton.onClick.AddListener(OnMainMenuButtonClicked);
            _settingsButton.onClick.AddListener(OnSettingsButtonClicked);

            if (_playerController != null)
            {
                _playerController.SetPlayerActive(false); // При активации WinView выключаем персонажа
            }
        }

        public override void Disable()
        {
            base.Disable();

            _nextButton.onClick.RemoveListener(OnNextButtonClicked);
            _mainMenuButton.onClick.RemoveListener(OnMainMenuButtonClicked);
            _settingsButton.onClick.RemoveListener(OnSettingsButtonClicked);

            if (_playerController != null)
            {
                _playerController.SetPlayerActive(true); // При выключении WinView включаем обратно персонажа
            }
        }

        private void OnNextButtonClicked()
        {
            onNextButtonClicked?.Invoke();
        }

        private void OnMainMenuButtonClicked()
        {
            onMainMenuButtonClicked?.Invoke();
        }

        private void OnSettingsButtonClicked()
        {
            onSettingsButtonClicked?.Invoke();
        }
    }
}