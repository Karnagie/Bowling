using UnityEngine;

namespace GameEssence
{
    [RequireComponent(typeof(Rigidbody))]
    public class WinBall : MonoBehaviour
    {
        [SerializeField] private float _maxSize = 5;
        [SerializeField] private float _force = 100;
        [SerializeField] private ParticleSystem _effect;
        
        public void Increase()
        {
            if(transform.lossyScale.x > _maxSize) return;
            transform.localScale += Vector3.one*0.1f;
        }

        public void Init()
        {
            gameObject.SetActive(true);
        }

        public void Throw()
        {
            _effect.Stop();
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.isKinematic = false;
            rb.AddForce(Vector3.forward * _force, ForceMode.Impulse);
        }
    }
}