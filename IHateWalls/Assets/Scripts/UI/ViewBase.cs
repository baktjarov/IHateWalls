using UnityEngine;

namespace UI.Views
{
    public abstract class ViewBase : MonoBehaviour
    {
        // Вызывается при загрузке объекта в сцене
        private void Awake()
        {
            // Вызов метода Disable() при запуске
            Disable();
        }

        // Метод для включения представления
        public virtual void Enable()
        {
            // Установка активности игрового объекта в true (включение)
            gameObject.SetActive(true);
        }

        // Метод для выключения представления
        public virtual void Disable()
        {
            // Установка активности игрового объекта в false (выключение)
            gameObject.SetActive(false);
        }
    }
}
