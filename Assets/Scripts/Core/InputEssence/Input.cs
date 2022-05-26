using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Core.InputEssence
{
    public abstract class Input : IInput
    {
        protected MainActions _actions;
        
        public Input()
        {
            _actions = new MainActions();
            _actions.Player.Touching.started += (ctx => OnClick?.Invoke(ctx));
            _actions.Enable();
        }

        public Action<InputAction.CallbackContext> OnClick { get; set; }
        
        public abstract Vector3 GetVelocity();
        
        public virtual void Destroy()
        {
            _actions.Player.Touching.Dispose();
            _actions = null;
        }
    }
}