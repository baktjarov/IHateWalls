using UnityEngine;
using UnityEngine.UI;

namespace UI.Views
{
    public class GameplayView : ViewBase
    {
        [SerializeField] private Slider _progressSlider;

        public void SetProgress(float progress)
        {
            if (_progressSlider.maxValue < 100)
            {
                _progressSlider.maxValue = 100;
            }

            _progressSlider.value = progress;
        }

    }
}
