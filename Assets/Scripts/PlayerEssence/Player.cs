using System;
using System.Collections;
using BreakableObjects.BallEssence;
using Core;
using Core.InputEssence;
using Core.MoverEssence;
using GameEssence;
using PathCreation;
using SettingsEssence;
using UnityEngine;
using Zenject;

namespace PlayerEssence
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private BallSpawner _spawner;
        [SerializeField] private Transform _target;
        [SerializeField] private float _speed = 1;
        [SerializeField] private float _limit = 1;
        
        private IMover _mover;
        
        [Inject] private IInput _input;

        private void Awake()
        {
            IMover forward = new TargetMover(transform, _target, _speed);
            IMover side = new InputMover(transform, _input, _limit);
            _mover = new PlayerMover(forward, side);
            _spawner.Init(transform);
            _spawner.Spawn().ShowInstant();
        }

        private void Update() => _mover.Move();

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position-Vector3.right*_limit, transform.position+Vector3.right*_limit);
        }

        public void End(WinBall ball)
        {
            _spawner.AddInBall(ball);
        }
    }
}