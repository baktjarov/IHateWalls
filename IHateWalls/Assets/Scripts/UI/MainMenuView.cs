using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Views
{
    public class MainMenuView : ViewBase
    {
        public Action onPlayButtonClicked;

        [SerializeField] private Button _playButton;
        [SerializeField] private Button _quitButton;

        public override void Enable()
        {
            base.Enable();
            _playButton.onClick.AddListener(OnPlayButtonClicked);
        }
        public override void Disable()
        {
            base.Disable();
            _playButton.onClick.RemoveListener(OnPlayButtonClicked);
        }

        private void OnPlayButtonClicked()
        {
            onPlayButtonClicked?.Invoke();
        }
    }
}

