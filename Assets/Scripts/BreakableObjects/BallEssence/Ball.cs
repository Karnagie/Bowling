using System;
using Core.EffectorEssence;
using Core.MoverEssence;
using DG.Tweening;
using GameEssence;
using PoolEssence;
using UnityEngine;

namespace BreakableObjects.BallEssence
{
    public class Ball : MonoBehaviour, IBreakable, IPoolObject<Ball>
    {
        [SerializeField] private float _moveSpeed = 0.2f;
        [SerializeField] private float _rotationSpeed = 2;
        [SerializeField] private float _showEffectSpeed = 1;
        [SerializeField] private float _hideEffectSpeed = 1;
        [SerializeField] private ParticleSystem _destroyEffect;
            
        private IEffector _effector;
        private IMover _mover;

        private void Awake()
        {
            _effector = new BallEffector(transform, _rotationSpeed);
            _mover = new BallMover(transform, GetComponent<Rigidbody>(), _moveSpeed);
            //_effector.Show(_showEffectSpeed);
        }

        private void FixedUpdate() => _mover?.Move();

        public async void Break()
        {
            _destroyEffect.Play();
            await _effector.HideAsync(_hideEffectSpeed);
            Pool.Return(this);
        }

        public void Init(IPool<Ball> pool)
        {
            Pool = pool;
            _effector.Hide(0);
            _effector.Show(_showEffectSpeed);
        }

        public IPool<Ball> Pool { get; private set; }

        public void ShowInstant()
        {
            _effector.StopAll();
            _effector.Show(0);
        }

        public void MoveTo(WinBall ball)
        {
            _mover = new EmptyMover();
            transform.DOKill();
            transform.parent = null;
            GetComponent<Rigidbody>().isKinematic = true;
            transform.DOMove(ball.transform.position, 0.5f).OnComplete((() =>
            {
                ball.Increase();
                Break();
            }));
        }

        public void TurnOffPhys()
        {
            GetComponent<Collider>().isTrigger = true;
        }
    }
}