// GENERATED AUTOMATICALLY FROM 'Assets/Resources/MainActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @MainActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @MainActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""MainActions"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""8d7bad1d-cffd-44c1-91ed-52984e089091"",
            ""actions"": [
                {
                    ""name"": ""Touching"",
                    ""type"": ""Button"",
                    ""id"": ""7f77b1df-76a7-460b-ab1a-b3894c02c6a0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""87600dbb-0ffa-4277-b51c-230e602a79c9"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Touching"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""066c192e-817a-4bcf-b904-220f8383eeba"",
                    ""path"": ""<Touchscreen>/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Touching"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Touching = m_Player.FindAction("Touching", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Touching;
    public struct PlayerActions
    {
        private @MainActions m_Wrapper;
        public PlayerActions(@MainActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Touching => m_Wrapper.m_Player_Touching;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Touching.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTouching;
                @Touching.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTouching;
                @Touching.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTouching;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Touching.started += instance.OnTouching;
                @Touching.performed += instance.OnTouching;
                @Touching.canceled += instance.OnTouching;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    public interface IPlayerActions
    {
        void OnTouching(InputAction.CallbackContext context);
    }
}
