using System.Threading.Tasks;
using BreakableObjects.BallEssence;
using DG.Tweening;
using UnityEngine;

namespace BreakableObjects.PinEssence
{
    [RequireComponent(typeof(Rigidbody))]
    public class Pin : MonoBehaviour, IBreakable
    {
        [SerializeField] private float _force = 100;
        
        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out Ball ball))
            {
                ball.Break();
                Break();
            }
        }

        public void Break()
        {
            _rigidbody.AddForce(GetRandomVelocity()*_force, ForceMode.Impulse);
            transform.DOScale(0, 2f)
                .SetDelay(1)
                .OnComplete((() => Destroy(gameObject)));
        }

        private Vector3 GetRandomVelocity()
        {
            Vector3 velocity = new Vector3();
            velocity.x = Random.Range(-1f, 1f);
            velocity.y = Random.Range(0.5f, 1.5f);
            velocity.z = Random.Range(1f, 3f);
            return velocity.normalized;
        }
    }
}