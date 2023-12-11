using UnityEngine;
using UnityEngine.UI;

namespace UI.Views
{
    public class GameplayView : ViewBase
    {
        [SerializeField] private Slider _progressSlider;

        public void SetProgress(float progress, int maxValue)
        {
            _progressSlider.maxValue = maxValue;

            _progressSlider.value = progress;
        }

    }
}
