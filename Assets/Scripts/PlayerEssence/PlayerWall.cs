using System;
using Core.MoverEssence;
using UnityEngine;

namespace PlayerEssence
{
    public class PlayerWall : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private IgnoreMask _mask;
        
        private IMover _mover;

        private void Awake()
        {
            _mover = new InstantMover(transform, _target, _mask);
        }

        private void Update() => _mover.Move();
    }
}