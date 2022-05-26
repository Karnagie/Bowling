using System;
using Core.InputEssence;
using DG.Tweening;
using PlayerEssence;
using UnityEngine;
using Zenject;

namespace GameEssence
{
    public class Win : MonoBehaviour
    {
        [SerializeField] private WinBall _ball;
        [SerializeField] private Transform _camPosition;

        private bool _isReady;

        [Inject] private IInput _input;

        private void Awake()
        {
            _input.OnClick += ctx =>
            {
                if (_isReady) _ball.Throw();
            };
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out Player player))
            {
                _isReady = true;
                _ball.Init();
                player.End(_ball);
                Camera.main.transform.DOMove(_camPosition.position, 1f);
                Camera.main.transform.DORotate(_camPosition.eulerAngles, 1f);
            }
        }
    }
}