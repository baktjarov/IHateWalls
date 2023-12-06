using UnityEngine;

namespace UI.Views
{
    public abstract class ViewBase : MonoBehaviour
    {
        private void Awake()
        {
            Disable();
        }

        public virtual void Enable()
        {
            gameObject.SetActive(true);
        }

        public virtual void Disable()
        {
            gameObject.SetActive(false);
        }
    }
}
