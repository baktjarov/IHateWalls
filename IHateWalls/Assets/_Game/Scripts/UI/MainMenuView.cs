using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Views
{
    public class MainMenuView : ViewBase
    {
        public Action onPlayButtonClicked;
        public Action onMainMenuSettingsButtonClicked;

        [SerializeField] private Button _playButton;
        [SerializeField] private Button _settingsButton;
        [SerializeField] private Button _quitButton;
        
        public override void Enable()
        {
            base.Enable();

            _playButton.onClick.AddListener(OnPlayButtonClicked);
            _settingsButton.onClick.AddListener(OnMainMenuSettingsButtonClicked);

        }

        public override void Disable()
        {
            base.Disable();

            _playButton.onClick.RemoveListener(OnPlayButtonClicked);
            _settingsButton.onClick.RemoveListener(OnMainMenuSettingsButtonClicked);
        }

        private void OnPlayButtonClicked()
        {
            onPlayButtonClicked?.Invoke();
        }

        private void OnMainMenuSettingsButtonClicked()
        {
            onMainMenuSettingsButtonClicked?.Invoke();
        }
    }
}