using System.Collections;
using UnityEngine;

namespace BreakableObjects.BallEssence
{
    public class BallJumper : MonoBehaviour
    {
        [SerializeField] private AnimationCurve _jumpCurve;
        [SerializeField] private float _height;
        [SerializeField] private float _speed;

        private float _defaultHeight;

        public void Jump()
        {
            StartCoroutine(Jumping());
        }

        private IEnumerator Jumping()
        {
            float distance = 0;
            _defaultHeight = transform.position.y;
            while (distance <= 1)
            {
                Vector3 pos = transform.position;
                pos.y = _defaultHeight;
                pos.y += _jumpCurve.Evaluate(distance)*_height;
                transform.position = pos;
                distance += _speed * Time.deltaTime;
                distance = Mathf.Min(1, distance);
                yield return new WaitForEndOfFrame();
            }
        }
    }
}