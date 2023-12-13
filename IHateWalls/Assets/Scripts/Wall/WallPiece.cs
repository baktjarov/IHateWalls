using Interfaces;
using UnityEngine;

namespace Walls
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(MeshCollider))]
    public class WallPiece : MonoBehaviour, IDamagable
    {
        public bool isRealeased { get; private set; }

        [SerializeField] private Rigidbody _rigidbody;

        private void OnValidate()
        {
            if (Application.isPlaying == true) return;

            if (_rigidbody == null)
            {
                _rigidbody = GetComponent<Rigidbody>();
            }

            _rigidbody.useGravity = false;
            _rigidbody.isKinematic = true;
            _rigidbody.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;

            GetComponent<MeshCollider>().convex = true;
        }

        public void Damage(float damage)
        {
            _rigidbody.useGravity = true;
            _rigidbody.isKinematic = false;

            isRealeased = true;
        }
    }
}
