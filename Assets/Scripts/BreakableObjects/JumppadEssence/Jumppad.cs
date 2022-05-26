using System;
using BreakableObjects.BallEssence;
using UnityEngine;

namespace BreakableObjects.JumppadEssence
{
    public class Jumppad : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out BallJumper jumper))
            {
                jumper.Jump();
            }
        }
    }
}