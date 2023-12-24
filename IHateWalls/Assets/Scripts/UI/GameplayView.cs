using UnityEngine;
using UnityEngine.UI;

namespace UI.Views
{
    public class GameplayView : ViewBase
    {
        // Поле для привязки компонента Slider из редактора Unity
        [SerializeField] private Slider _progressSlider;

        // Метод для установки прогресса на слайдере
        public void SetProgress(float progress, int maxValue)
        {
            // Установка максимального значения слайдера
            _progressSlider.maxValue = maxValue;
            // Установка текущего значения слайдера (прогресса)
            _progressSlider.value = progress;
        }
    }
}
