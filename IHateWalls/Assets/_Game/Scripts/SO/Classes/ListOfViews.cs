using Interfaces;
using System.Collections.Generic;
using UI.Views;
using UnityEngine;

namespace SO
{
    [CreateAssetMenu(fileName = nameof(ListOfViews),
                    menuName = "Scriptables/" + nameof(ListOfViews))]
    public class ListOfViews : ScriptableObject, IService
    {
        [SerializeField] private List<ViewBase> _views = new();

        public T GetView<T>() where T : ViewBase
        {
            T view = null;

            foreach (ViewBase viewBase in _views)
            {
                if (viewBase is T == true)
                {
                    view = (T)viewBase;
                    continue;
                }
            }

            return view;
        }

        public bool TryGetView<T>(out T view) where T : ViewBase
        {
            view = GetView<T>();

            return view != null;
        }
    }
}