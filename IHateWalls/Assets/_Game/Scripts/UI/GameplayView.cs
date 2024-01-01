using SO;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Views
{
    public class GameplayView : ViewBase
    {
        public delegate void GameplayViewEvent(); // Определяем делегат для событий
        public static event GameplayViewEvent OnGameplayViewEnabled; // Событие для включения GameplayView
        public static event GameplayViewEvent OnGameplayViewDisabled; // Событие для отключения GameplayView

        [SerializeField] private Slider _progressSlider;
        [SerializeField] private ListOfWalls _walls;

        private void Start()
        {
            if (_progressSlider == null)
            {
                _progressSlider = GetComponentInChildren<Slider>(true);
            }

            // В момент старта, вызываем событие включения GameplayView
            EnableGameplayView();
        }

        public void SetProgress(float progress, int maxValue)
        {
            _progressSlider.maxValue = maxValue;
            _progressSlider.value = progress;
        }

        private void OnDisable()
        {
            // Вызываем событие отключения GameplayView перед его отключением
            DisableGameplayView();
        }

        private void EnableGameplayView()
        {
            // Проверяем, есть ли подписчики на событие включения
            if (OnGameplayViewEnabled != null)
            {
                OnGameplayViewEnabled(); // Вызываем событие
            }
        }

        private void DisableGameplayView()
        {
            // Проверяем, есть ли подписчики на событие отключения
            if (OnGameplayViewDisabled != null)
            {
                OnGameplayViewDisabled(); // Вызываем событие
            }
        }
    }
}
