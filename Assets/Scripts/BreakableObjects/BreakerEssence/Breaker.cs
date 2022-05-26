using System;
using UnityEngine;

namespace BreakableObjects.BreakerEssence
{
    public class Breaker : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IBreakable breakable))
            {
                breakable.Break();
            }
        }
    }
}