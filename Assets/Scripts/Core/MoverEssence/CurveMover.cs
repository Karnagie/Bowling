using PathCreation;
using UnityEngine;

namespace Core.MoverEssence
{
    public class CurveMover : IMover
    {
        private Transform _transform;
        private PathCreator _pathCreator;
        private float _speed;
        private EndOfPathInstruction _endOfPathInstruction = EndOfPathInstruction.Stop;
        private float _distanceTravelled;
        
        public CurveMover(Transform transform, PathCreator pathCreator, float speed)
        {
            _transform = transform;
            _pathCreator = pathCreator;
            _speed = speed;
        }
        
        public void Move()
        {
            _distanceTravelled += _speed * Time.deltaTime;
            _transform.position = _pathCreator.path.GetPointAtDistance(_distanceTravelled, _endOfPathInstruction);
            _transform.rotation = _pathCreator.path.GetRotationAtDistance(_distanceTravelled, _endOfPathInstruction);
        }
    }
}