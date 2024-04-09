using System.Collections;
using Interfaces;
using SO;
using UnityEngine;

namespace Player
{
    public class BulletBase : MonoBehaviour
    {
        [SerializeField] private BulletPooling _pooling;
        [SerializeField] private float _lifetime = 5;

        private float _damage;

        public void Inititlize(BulletPooling pooling)
        {
            _pooling = pooling;
        }

        private void OnEnable()
        {
            StartCoroutine(Put_Coroutine(_lifetime));
        }

        private void OnDisable()
        {
            StopCoroutine(Put_Coroutine(_lifetime));
        }

        private IEnumerator Put_Coroutine(float delay)
        {
            yield return new WaitForSecondsRealtime(delay);
            _pooling.Put(this);
        }

        public void SetDamage(float newDamage)
        {
            _damage = newDamage;
        }

        private void OnTriggerEnter(Collider other)
        {
            var damagable = other.GetComponent<IDamagable>();

            if (damagable != null)
            {
                damagable.TakeDamage(_damage);
            }
        }
    }
}