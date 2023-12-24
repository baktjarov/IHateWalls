using Interfaces;
using UnityEngine;

namespace Player
{
    // Указание, что на объекте должен быть компонент Rigidbody
    [RequireComponent(typeof(Rigidbody))]
    // Указание, что на объекте должен быть компонент SphereCollider
    [RequireComponent(typeof(SphereCollider))]
    public class Bullet : MonoBehaviour
    {
        [Header("Settings")]
        // Поле для урона пули (с возможностью изменения в инспекторе)
        [SerializeField] private float _damage = 100;
        // Поле для времени уничтожения пули (с возможностью изменения в инспекторе)
        [SerializeField] private float _destroyDelay = 5f;

        [Header("Components")]
        // Поле для Rigidbody (с возможностью привязки в инспекторе)
        [SerializeField] private Rigidbody _rigidbody;

        // Метод, вызываемый при запуске объекта
        private void Start()
        {
            // Уничтожение пули через заданное время
            Destroy(gameObject, _destroyDelay);
        }

        // Метод, вызываемый при столкновении пули с другим коллайдером
        private void OnTriggerEnter(Collider colliderObject)
        {
            // Получение компонента IDamagable из коллайдера
            IDamagable damagable = colliderObject.GetComponent<IDamagable>();
            // Проверка наличия компонента IDamagable
            if (damagable != null)
            {
                // Нанесение урона объекту, если он поддерживает интерфейс IDamagable
                damagable.Damage(_damage);
            }
        }

        // Публичный метод для придания силы пули
        public void AddForce(Vector3 force)
        {
            // Добавление силы к Rigidbody пули
            _rigidbody.AddForce(force);
        }
    }
}