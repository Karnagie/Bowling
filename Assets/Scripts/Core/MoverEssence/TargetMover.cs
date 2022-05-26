using UnityEngine;

namespace Core.MoverEssence
{
    public class TargetMover : IMover
    {
        private Transform _transform;
        private Transform _target;
        private float _speed;
        private float _distance;
        
        public TargetMover(Transform transform, Transform target, float speed)
        {
            _transform = transform;
            _target = target;
            _speed = speed;
        }
        
        public void Move()
        {
            _distance = _speed * Time.deltaTime;
            Vector3 irgnoreX = _transform.position + (_target.position - _transform.position).normalized * _distance;//Vector3.Lerp(_transform.position, _target.position, _distance);
            irgnoreX.z = Mathf.Min(irgnoreX.z, _target.position.z);
            irgnoreX.x = _transform.position.x;
            _transform.position = irgnoreX;
        }
    }
}