using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Views
{
    public class WinView : ViewBase
    {
        public Action onReplayButtonClicked;
        public Action onMainMenuButtonClicked;

        [SerializeField] private Button _replayButton;
        [SerializeField] private Button _mainMenuButton;

        public override void Enable()
        {
            base.Enable();

            _replayButton.onClick.AddListener(OneReplayButtonClicked);
            _mainMenuButton.onClick.AddListener(OneMainMenuButtonClicked);
        }
        public override void Disable()
        {
            base.Disable();

            _replayButton.onClick.RemoveListener(OneReplayButtonClicked);
            _mainMenuButton.onClick.RemoveListener(OneMainMenuButtonClicked);
        }

        private void OneReplayButtonClicked()
        {
            onReplayButtonClicked?.Invoke();
        }
        private void OneMainMenuButtonClicked()
        {
            onMainMenuButtonClicked?.Invoke();
        }
    }
}
