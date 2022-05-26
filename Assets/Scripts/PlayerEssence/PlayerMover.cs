using Core.InputEssence;
using Core.MoverEssence;
using UnityEngine;

namespace PlayerEssence
{
    public class PlayerMover : IMover
    {
        private IMover _forward;
        private IMover _side;
        
        public PlayerMover(IMover forward, IMover side)
        {
            _forward = forward;
            _side = side;
        }
        
        public void Move()
        {
            _forward.Move();
            _side.Move();
        }
    }
}