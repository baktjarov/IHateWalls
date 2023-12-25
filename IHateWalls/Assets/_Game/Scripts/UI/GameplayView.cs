using SO;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Views
{
    public class GameplayView : ViewBase
    {
        [SerializeField] private Slider _progressSlider;
        [SerializeField] private ListOfWalls _walls;

        private void Start()
        {
            if (_progressSlider == null)
            {
                _progressSlider = GetComponentInChildren<Slider>(true);
            }
        }

        public void SetProgress(float progress, int maxValue)
        {
            _progressSlider.maxValue = maxValue;
            _progressSlider.value = progress;
        }
    }
}