using System.Threading.Tasks;
using Core.EffectorEssence;
using DG.Tweening;
using UnityEngine;

namespace BreakableObjects.BallEssence
{
    public class BallEffector : IEffector
    {
        private Transform _transform;
        private Vector3 _defaultScale;
        private float _rotationSpeed;

        public BallEffector(Transform transform, float rotationSpeed)
        {
            _transform = transform;
            _defaultScale = transform.localScale;
            _rotationSpeed = rotationSpeed;
        }
        
        public void Show(float showSpeed)
        {
            _transform.localScale = Vector3.zero;
            _transform.DOScale(_defaultScale, showSpeed);
            StartRandomRotation();
        }

        private void StartRandomRotation()
        {
            float randomSpeed = Random.Range(_rotationSpeed * 0.9f, _rotationSpeed);
            _transform.DOLocalRotate(new Vector3(360, 0, 0), randomSpeed, RotateMode.FastBeyond360)
                .SetEase(Ease.Linear)
                .SetLoops(-1);
        }

        public void Hide(float hideSpeed)
        {
            _transform.DOScale(0, hideSpeed);
        }

        public void StopAll()
        {
            _transform.DOKill();
        }

        public async Task HideAsync(float hideSpeed)
        {
            await _transform.DOScale(0, hideSpeed).AsyncWaitForCompletion();
        }
    }
}