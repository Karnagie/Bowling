using System;
using UnityEngine;

namespace Core.MoverEssence
{
    public class InstantMover : IMover
    {
        private Transform _transform;
        private Transform _target;
        private IgnoreMask _mask;
        public InstantMover(Transform transform, Transform target, IgnoreMask mask)
        {
            _transform = transform;
            _target = target;
            _mask = mask;
        }
        
        public void Move()
        {
            Vector3 newPos = _target.position;
            if (!_mask.X) newPos.x = _transform.position.x;
            if (!_mask.Y) newPos.y = _transform.position.y;
            if (!_mask.Z) newPos.z = _transform.position.z;
            
            _transform.position = newPos;
        }
    }

    [Serializable]
    public struct IgnoreMask
    {
        public bool X;
        public bool Y;
        public bool Z;
    }
}