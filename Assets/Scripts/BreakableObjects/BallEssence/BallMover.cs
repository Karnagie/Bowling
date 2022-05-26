using Core.MoverEssence;
using UnityEngine;

namespace BreakableObjects.BallEssence
{
    public class BallMover : IMover
    {
        private Transform _transform;
        private Rigidbody _rigidbody;
        private float _speed;
        private float _distance;

        public BallMover(Transform transform, float speed)
        {
            _transform = transform;
            _speed = speed;
        }
        
        public BallMover(Transform transform, Rigidbody rigidbody, float speed)
        {
            _transform = transform;
            _rigidbody = rigidbody;
            _speed = speed;
        }
        
        public void Move()
        {
            Vector3 target = new Vector3(_transform.localPosition.x / 2, _transform.localPosition.y, 0);//Vector3.Lerp(_transform.localPosition, new Vector3(_transform.localPosition.x/2, _transform.localPosition.y, 0), _speed);
            target.y = _transform.localPosition.y;
            //_transform.localPosition = target;
            Vector3 vel = (target - _transform.localPosition) * _speed * Time.deltaTime;
            if(vel.magnitude < 1f) vel = Vector3.zero;
            _rigidbody.velocity = vel;
        }
    }
}