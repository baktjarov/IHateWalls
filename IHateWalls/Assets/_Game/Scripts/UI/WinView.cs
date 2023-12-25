using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Views
{
    public class WinView : ViewBase
    {
        public Action onNextButtonClicked;
        public Action onMainMenuButtonClicked;

        [SerializeField] private Button _nextButton;
        [SerializeField] private Button _mainMenuButton;

        public override void Enable()
        {
            base.Enable();

            _nextButton.onClick.AddListener(OnNextButtonClicked);
            _mainMenuButton.onClick.AddListener(OnMainMenuButtonClicked);
        }

        public override void Disable()
        {
            base.Disable();

            _nextButton.onClick.RemoveListener(OnNextButtonClicked);
            _mainMenuButton.onClick.RemoveListener(OnMainMenuButtonClicked);
        }

        private void OnNextButtonClicked()
        {
            onNextButtonClicked?.Invoke();
        }

        private void OnMainMenuButtonClicked()
        {
            onMainMenuButtonClicked?.Invoke();
        }
    }
}