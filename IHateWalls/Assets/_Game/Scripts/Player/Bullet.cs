﻿using Interfaces;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(SphereCollider))]

    public class Bullet : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private float _damage = 100;
        [SerializeField] private float _destroyDelay = 5f;

        private void Start()
        {
            Destroy(gameObject, _destroyDelay);
        }

        private void OnTriggerEnter(Collider colliderObject)
        {
            IDamagable damagable = colliderObject.GetComponent<IDamagable>();

            if (damagable != null)
            {
                damagable.Damage(_damage);
            }
        }

        public void AddForce(Vector3 force)
        {
            _rigidbody.AddForce(force);
        }
    }
}