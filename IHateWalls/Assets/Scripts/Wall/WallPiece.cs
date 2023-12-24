using Interfaces;
using UnityEngine;

namespace Walls
{
    // Требуется компонент Rigidbody для объекта
    [RequireComponent(typeof(Rigidbody))]
    // Требуется компонент MeshCollider для объекта
    [RequireComponent(typeof(MeshCollider))]
    public class WallPiece : MonoBehaviour, IDamagable
    {
        // Переменная, отвечающая за состояние разрушения
        public bool isRealeased { get; private set; }

        // Ссылка на компонент Rigidbody
        [SerializeField] private Rigidbody _rigidbody;

        // Вызывается при валидации объекта в редакторе Unity
        private void OnValidate()
        {
            // Если игра запущена, прервать выполнение метода
            if (Application.isPlaying == true) return;

            // Если Rigidbody не задан в редакторе, получить его
            if (_rigidbody == null)
            {
                _rigidbody = GetComponent<Rigidbody>();
            }

            // Отключить гравитацию
            _rigidbody.useGravity = false;
            // Сделать объект кинематическим (не реагирующим на физику)
            _rigidbody.isKinematic = true;
            // Установить режим детекции коллизий
            _rigidbody.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;

            // Установить MeshCollider в выпуклый режим
            GetComponent<MeshCollider>().convex = true;
        }

        // Вызывается при старте объекта
        private void Start()
        {
            // Установить начальный масштаб объекта
            SetScale();
        }

        // Начальный масштаб объекта
        private float _scale = 1;
        // Вызывается каждый кадр
        private void Update()
        {
            // Если объект разрушен
            if (isRealeased == true)
            {
                // Уменьшить масштаб объекта со временем
                _scale -= 1f * Time.deltaTime;

                // Установить текущий масштаб объекта
                SetScale();

                // Если масштаб стал очень маленьким, уничтожить объект
                if (_scale < 0.1f)
                {
                    // Уничтожить объект
                    Destroy(gameObject);
                }
            }
        }

        // Установить масштаб объекта
        private void SetScale()
        {
            // Изменить масштаб объекта
            transform.localScale = Vector3.one * _scale;
        }

        // Реализация метода Damage из интерфейса IDamagable
        public void Damage(float damage)
        {
            // Включить гравитацию для объекта
            _rigidbody.useGravity = true;
            // Сделать объект реагирующим на физику
            _rigidbody.isKinematic = false;

            // Отметить объект как разрушенный
            isRealeased = true;
        }
    }
}
