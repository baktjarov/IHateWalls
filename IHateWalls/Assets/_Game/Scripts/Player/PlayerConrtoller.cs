using UnityEngine;
using UI.Views;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        private void Awake()
        {
            GameplayView.OnGameplayViewEnabled += EnablePlayer;
            GameplayView.OnGameplayViewDisabled += DisablePlayer;
        }

        private void OnDestroy()
        {
            GameplayView.OnGameplayViewEnabled -= EnablePlayer;
            GameplayView.OnGameplayViewDisabled -= DisablePlayer;
        }

        private void EnablePlayer()
        {
            gameObject.SetActive(true);
        }

        private void DisablePlayer()
        {
            gameObject.SetActive(false);
        }
    }
}

