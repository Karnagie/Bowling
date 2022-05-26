using System;
using Core.InputEssence;
using UnityEngine;

namespace Core.MoverEssence
{
    public class InputMover : IMover
    {
        private Transform _transform;
        private IInput _input;
        private float _limit;
        
        public InputMover(Transform transform, IInput input, float limit)
        {
            _transform = transform;
            _input = input;
            _limit = limit;
        }
        
        public void Move()
        {
            Vector3 newPos = _transform.position + (Vector3.right * _input.GetVelocity().x);
            float limitedValue = Mathf.Min(_limit, newPos.x);
            limitedValue = Mathf.Max(-_limit, limitedValue);
            newPos.x = limitedValue;
            _transform.position = newPos;
        }
    }
}