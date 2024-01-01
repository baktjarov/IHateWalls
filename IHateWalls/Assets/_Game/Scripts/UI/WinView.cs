using System;
using UnityEngine;
using UnityEngine.UI;

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

        public override void Enable()
        {
            base.Enable();

            _nextButton.onClick.AddListener(OnNextButtonClicked);
            _mainMenuButton.onClick.AddListener(OnMainMenuButtonClicked);
            _settingsButton.onClick.AddListener(OnSettingsButtonClicked);
        }

        public override void Disable()
        {
            base.Disable();

            _nextButton.onClick.RemoveListener(OnNextButtonClicked);
            _mainMenuButton.onClick.RemoveListener(OnMainMenuButtonClicked);
            _settingsButton.onClick.RemoveListener(OnSettingsButtonClicked);
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