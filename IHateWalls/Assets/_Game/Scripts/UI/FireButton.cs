using UnityEngine;
using UnityEngine.UI;
using Player;

namespace UI.Views
{
    [RequireComponent(typeof(Button))] // Добавим компонент кнопки автоматически
    public class FireButton : MonoBehaviour
    {
        public Image progressBar;

        private float reloadTime = 3.0f;
        private float timer = 0.0f;
        private bool isReloading = false;

        private BulletShooter _bulletShooter; // Ссылка на компонент BulletShooter

        void Start()
        {
            // Получаем ссылку на компонент BulletShooter
            _bulletShooter = FindObjectOfType<BulletShooter>();

            // Привязываем обработчик нажатия кнопки
            var button = GetComponent<Button>();
            button.onClick.AddListener(OnButtonClick);
        }

        void Update()
        {
            if (isReloading)
            {
                timer += Time.deltaTime;
                progressBar.fillAmount = timer / reloadTime;

                if (timer >= reloadTime)
                {
                    isReloading = false;
                    timer = 0.0f;
                }
            }
        }

        public void OnButtonClick()
        {
            if (!isReloading)
            {
                // Проверяем, есть ли компонент BulletShooter
                if (_bulletShooter != null)
                {
                    _bulletShooter.Shoot(); // Вызываем метод Shoot() из BulletShooter
                }

                isReloading = true;
            }
        }
    }
}
