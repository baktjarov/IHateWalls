using UnityEngine;
using UnityEngine.UI;
using Player;

namespace UI.Views
{
    [RequireComponent(typeof(Button))]
    public class FireButton : MonoBehaviour
    {
        public Image progressBar;

        private float reloadTime = 3.0f;
        private float timer = 0.0f;
        private bool isReloading = false;
        
        private BulletShooter _bulletShooter;

        private void Start()
        {
            var button = GetComponent<Button>();
            button.onClick.AddListener(OnButtonClick);

            _bulletShooter = FindObjectOfType<BulletShooter>();
        }

         private void Update()
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
                _bulletShooter.Shoot();
                isReloading = true;
            }
        }
    }
}
