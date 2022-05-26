using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Core.InputEssence
{
    public interface IInput
    {
        Action<InputAction.CallbackContext> OnClick { get; set; }

        Vector3 GetVelocity();

        void Destroy();
    }
}