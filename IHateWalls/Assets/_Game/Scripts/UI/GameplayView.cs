using SO;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Views
{
    public class GameplayView : ViewBase
    {
        public delegate void GameplayViewEvent();
        public static event GameplayViewEvent OnGameplayViewEnabled; 
        public static event GameplayViewEvent OnGameplayViewDisabled;

        [SerializeField] private Slider _progressSlider;
        [SerializeField] private ListOfWalls _walls;

        private void Start()
        {
            if (_progressSlider == null)
            {
                _progressSlider = GetComponentInChildren<Slider>(true);
            }

            EnableGameplayView();
        }

        public void SetProgress(float progress, int maxValue)
        {
            _progressSlider.maxValue = maxValue;
            _progressSlider.value = progress;
        }

        private void OnDisable()
        {
            DisableGameplayView();
        }

        private void EnableGameplayView()
        {
            if (OnGameplayViewEnabled != null)
            {
                OnGameplayViewEnabled();
            }
        }

        private void DisableGameplayView()
        {
            if (OnGameplayViewDisabled != null)
            {
                OnGameplayViewDisabled();
            }
        }
    }
}
