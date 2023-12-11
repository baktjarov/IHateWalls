using Interfaces;
using UnityEngine;

namespace Walls
{
    public class WallPiece : MonoBehaviour, IDamagable
    {
        public bool isRealeased { get; private set; }

        [SerializeField] private Rigidbody _rigidbody;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void Damage(float damage)
        {
            _rigidbody.useGravity = true;
            _rigidbody.isKinematic = false;

            isRealeased = true;
        }
    }
}
