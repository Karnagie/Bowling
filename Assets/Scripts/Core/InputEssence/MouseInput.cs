using UnityEngine;
using UnityEngine.InputSystem;

namespace Core.InputEssence
{
    public class MouseInput : Input
    {
        private Vector3 _oldMousePosition;
        private Vector3 _newMousePosition;
        private bool _isTouching;
        private float _sensitivity;

        public MouseInput(float sensitivity)
        {
            _sensitivity = sensitivity;
            _actions.Player.Touching.started += StartTouching;
            _actions.Player.Touching.canceled += EndTouching;
        }
        
        public override Vector3 GetVelocity()
        {
            if (_isTouching) _newMousePosition = Mouse.current.position.ReadValue();
            Vector3 pos = _newMousePosition-_oldMousePosition;
            _oldMousePosition = _newMousePosition;
            return pos*_sensitivity;
        }

        private void StartTouching(InputAction.CallbackContext ctx)
        {
            _oldMousePosition = Mouse.current.position.ReadValue();
            _isTouching = true;
        }
        
        private void EndTouching(InputAction.CallbackContext ctx)
        {
            _isTouching = false;
        }
    }
}