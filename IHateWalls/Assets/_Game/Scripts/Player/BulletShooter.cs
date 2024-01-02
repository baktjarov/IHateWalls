using UnityEngine;
using UI.Views;

namespace Player
{
    public class BulletShooter : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private float _force = 2500;

        [Header("Components")]
        [SerializeField] private Camera _camera;
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private Transform _shootSocket;

        private void Start()
        {
            _camera = FindObjectOfType<Camera>(true);
        }

        public void Shoot()
        {
            Bullet bulletInstance = Instantiate(_bulletPrefab, _shootSocket.position, _shootSocket.rotation);

            Vector3 shootDirection = _shootSocket.forward;
            bulletInstance.AddForce(shootDirection * _force);
        }
    }
}