using Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI.Views;

namespace SO
{
    // Атрибут CreateAssetMenu указывает на то, как будет создаваться данный объект в редакторе Unity
    [CreateAssetMenu(fileName = nameof(ListOfViews),
                     menuName = "Scriptables/" + nameof(ListOfViews))]
    public class ListOfViews : ScriptableObject, IService
    {
        // Приватное поле, хранящее список представлений
        [SerializeField] private List<ViewBase> _views = new();

        // Метод для получения представления по указанному типу
        public T GetView<T>() where T : ViewBase
        {
            // Инициализация переменной представления
            T view = null;

            // Перебор всех представлений в списке
            foreach (ViewBase viewBase in _views)
            {
                // Проверка соответствия типа представления требуемому типу
                if (viewBase is T == true)
                {
                    // Приведение к нужному типу, если найдено соответствующее представление
                    view = (T)viewBase;
                    // Продолжение цикла
                    continue;
                }
            }

            // Возврат найденного представления
            return view;
        }

        // Метод для попытки получения представления по указанному типу
        public bool TryGetView<T>(out T view) where T : ViewBase
        {
            // Получение представления по указанному типу
            view = GetView<T>();

            // Возврат true, если представление найдено, иначе - false
            return view != null;
        }
    }
}