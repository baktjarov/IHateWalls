using UnityEngine;
using UnityEngine.EventSystems;

namespace FWC
{
    public class HoverAnim : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] private float scaleChange = 1.1f;
        [SerializeField] private AudioSource source;

        public void OnPointerDown(PointerEventData eventData)
        {
            transform.localScale *= scaleChange;

            if (source != null && source.clip != null)
                source.PlayOneShot(source.clip);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
