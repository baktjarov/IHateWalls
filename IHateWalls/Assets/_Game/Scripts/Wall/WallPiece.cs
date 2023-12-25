using Interfaces;
using UnityEngine;

namespace Walls
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(MeshCollider))]
    public class WallPiece : MonoBehaviour, IDamagable
    {
        [field: SerializeField] public bool isRealeased { get; private set; }

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

        private void Start()
        {
            SetScale();
        }

        private float _scale = 1;
        private void Update()
        {
            if (isRealeased == true)
            {
                _scale -= 0.25f * Time.deltaTime;

                SetScale();

                if (_scale < 0.1f)
                {
                    Destroy(gameObject);
                }
            }
        }

        private void SetScale()
        {
            transform.localScale = Vector3.one * _scale;
        }

        public void Damage(float damage)
        {
            _rigidbody.useGravity = true;
            _rigidbody.isKinematic = false;

            isRealeased = true;
        }
    }
}