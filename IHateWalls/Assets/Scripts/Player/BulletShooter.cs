using UnityEngine;

namespace Player
{
    public class BulletShooter : MonoBehaviour
    {
        [Header("Settings")]
        // Сила выстрела пули
        [SerializeField] private float _force = 2500;

        // Заголовок для отображения в инспекторе
        [Header("Components")]
        // Камера для определения направления выстрела
        [SerializeField] private Camera _camera;
        // Префаб пули
        [SerializeField] private Bullet _bulletPrefab;
        // Точка выстрела пули
        [SerializeField] private Transform _shootSocket;

        // Вызывается при старте объекта
        private void Start()
        {
            // Находит активную камеру на сцене
            _camera = FindObjectOfType<Camera>(true);
        }

        // Вызывается каждый кадр
        private void Update()
        {
            // Проверяет, была ли отпущена левая кнопка мыши
            if (Input.GetMouseButtonUp(0))
            {
                // Если кнопка была отпущена, выполняет выстрел
                Shoot();
            }
        }

        // Метод для выполнения выстрела
        private void Shoot()
        {
            // Создание экземпляра пули
            Bullet bulletInstance = Instantiate(_bulletPrefab, _shootSocket.position, _shootSocket.rotation);

            // Создание луча от камеры в позицию указателя мыши на экране
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            // Придание силы пули в направлении указателя мыши с использованием силы _force 
            bulletInstance.AddForce(ray.direction * _force);
        }
    }
}