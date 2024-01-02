using UnityEngine;

namespace Player
{
    public class WeaponRotator : MonoBehaviour
    {
        [SerializeField] private Transform _base; // Основание пушки
        [SerializeField] private Transform _barrel; // Ствол пушки
        [SerializeField] private float _sensitivity = 0.25f; // Чувствительность для поворота
        [SerializeField] private float _maxLeftRotation = -20f; // Максимальный угол поворота влево
        [SerializeField] private float _maxRightRotation = 20f; // Максимальный угол поворота вправо
        [SerializeField] private float _maxUpRotation = 25f; // Максимальный угол поворота вверх
        [SerializeField] private float _maxDownRotation = -10f; // Максимальный угол поворота вниз

        private float _currentBarrelXAngle;
        private float _currentBaseYAngle;
        private Vector2 _touchOrigin = Vector2.zero;

        private void Update()
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    _touchOrigin = touch.position;
                }
                else if (touch.phase == TouchPhase.Moved)
                {
                    Vector2 touchDelta = touch.position - _touchOrigin;
                    RotateWeapon(touchDelta.x, touchDelta.y);
                }
            }
        }

        private void RotateWeapon(float xAngle, float yAngle)
        {
            xAngle *= _sensitivity;
            _currentBaseYAngle -= xAngle;
            _currentBaseYAngle = Mathf.Clamp(_currentBaseYAngle, -_maxRightRotation, -_maxLeftRotation);
            _base.localRotation = Quaternion.Euler(0, _currentBaseYAngle, 0);

            yAngle *= _sensitivity;
            _currentBarrelXAngle += yAngle;
            _currentBarrelXAngle = Mathf.Clamp(_currentBarrelXAngle, _maxDownRotation, _maxUpRotation);
            _barrel.localRotation = Quaternion.Euler(_currentBarrelXAngle, 0, 0);
        }
    }
}
