using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Views
{
    public class SettingsView : ViewBase
    {
        public Action onBackButtonClicked;

        [SerializeField] private Button _backButton;

        public override void Enable()
        {
            base.Enable();

            _backButton.onClick.AddListener(OnBackButtonClicked);
        }

        public override void Disable()
        {
            base.Disable();

            _backButton.onClick.RemoveListener(OnBackButtonClicked);
        }

        private void OnBackButtonClicked()
        {
            onBackButtonClicked?.Invoke();
        }
    }
}
