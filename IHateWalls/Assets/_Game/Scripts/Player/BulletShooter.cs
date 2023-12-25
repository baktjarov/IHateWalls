using UnityEngine;

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

        private void Update()
        {
            if (Input.GetMouseButtonUp(0))
            {
                Shoot();
            }
        }

        private void Shoot()
        {
            Bullet bulletInstance = Instantiate(_bulletPrefab, _shootSocket.position, _shootSocket.rotation);

            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            bulletInstance.AddForce(ray.direction * _force);
        }
    }
}