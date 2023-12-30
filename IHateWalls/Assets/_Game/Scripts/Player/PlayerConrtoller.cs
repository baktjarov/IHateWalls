using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private GameObject _playerObject; // Ссылка на объект персонажа

        private bool isPlayerActive = true;

        private void Start()
        {
            SetPlayerActive(true); // При старте убедимся, что персонаж включен
        }

        public void SetPlayerActive(bool isActive)
        {
            isPlayerActive = isActive;

            // Проверяем, что объект персонажа был привязан в редакторе Unity
            if (_playerObject != null)
            {
                _playerObject.SetActive(isActive);
            }
            else
            {
                Debug.LogError("Player object reference is missing!");
            }
        }
    }
}
