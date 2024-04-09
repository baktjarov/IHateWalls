using SO;
using UnityEngine;

namespace Player
{
    public class BulletShooter : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private float _bulletSpeed = 25;
        [SerializeField] private Transform _shootPosition;

        [Header("Components")]
        [SerializeField] private BulletPooling _bulletPooling;

        public void Shoot()
        {
            var bullet = _bulletPooling.Get(_shootPosition.position, _shootPosition.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * _bulletSpeed;
            bullet.Inititlize(_bulletPooling);
        }
    }
}