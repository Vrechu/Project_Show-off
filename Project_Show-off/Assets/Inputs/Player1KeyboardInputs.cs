//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/Inputs/PlayerInplutActions.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @Player1KeyboardInputs : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Player1KeyboardInputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInplutActions"",
    ""maps"": [
        {
            ""name"": ""Ingame"",
            ""id"": ""b836208e-e245-4c64-829d-5219672e091b"",
            ""actions"": [
                {
                    ""name"": ""Walk"",
                    ""type"": ""Value"",
                    ""id"": ""5f0515ed-d1d1-4d28-8f8e-41c4373dec74"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": ""Hold"",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""946076e2-47ea-4a42-a2b5-f703da1593f7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""5d8c6c18-ec53-40cf-a1cf-69f63747ac65"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard1"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5dc4f53b-ca3c-460f-b187-537aadeb4694"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""f3072608-876c-49bc-a10a-2cdf3221dd32"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""ce42129f-9563-4853-83da-acb39387e122"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard1"",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""803f2ebd-b71b-4cb8-b4dc-8141fe658cb7"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard1"",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""ed9e5304-b039-41f6-8d63-6ac33100fcb8"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard1"",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""67e3c941-c8cb-4f87-b529-f93cdeb0d696"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard1"",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""7d7770b1-7f47-42a2-9ff1-747055cda5ac"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard1"",
            ""bindingGroup"": ""Keyboard1"",
            ""devices"": []
        },
        {
            ""name"": ""Controller"",
            ""bindingGroup"": ""Controller"",
            ""devices"": []
        }
    ]
}");
        // Ingame
        m_Ingame = asset.FindActionMap("Ingame", throwIfNotFound: true);
        m_Ingame_Walk = m_Ingame.FindAction("Walk", throwIfNotFound: true);
        m_Ingame_Jump = m_Ingame.FindAction("Jump", throwIfNotFound: true);
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
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Ingame
    private readonly InputActionMap m_Ingame;
    private IIngameActions m_IngameActionsCallbackInterface;
    private readonly InputAction m_Ingame_Walk;
    private readonly InputAction m_Ingame_Jump;
    public struct IngameActions
    {
        private @Player1KeyboardInputs m_Wrapper;
        public IngameActions(@Player1KeyboardInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Walk => m_Wrapper.m_Ingame_Walk;
        public InputAction @Jump => m_Wrapper.m_Ingame_Jump;
        public InputActionMap Get() { return m_Wrapper.m_Ingame; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(IngameActions set) { return set.Get(); }
        public void SetCallbacks(IIngameActions instance)
        {
            if (m_Wrapper.m_IngameActionsCallbackInterface != null)
            {
                @Walk.started -= m_Wrapper.m_IngameActionsCallbackInterface.OnWalk;
                @Walk.performed -= m_Wrapper.m_IngameActionsCallbackInterface.OnWalk;
                @Walk.canceled -= m_Wrapper.m_IngameActionsCallbackInterface.OnWalk;
                @Jump.started -= m_Wrapper.m_IngameActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_IngameActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_IngameActionsCallbackInterface.OnJump;
            }
            m_Wrapper.m_IngameActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Walk.started += instance.OnWalk;
                @Walk.performed += instance.OnWalk;
                @Walk.canceled += instance.OnWalk;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
            }
        }
    }
    public IngameActions @Ingame => new IngameActions(this);
    private int m_Keyboard1SchemeIndex = -1;
    public InputControlScheme Keyboard1Scheme
    {
        get
        {
            if (m_Keyboard1SchemeIndex == -1) m_Keyboard1SchemeIndex = asset.FindControlSchemeIndex("Keyboard1");
            return asset.controlSchemes[m_Keyboard1SchemeIndex];
        }
    }
    private int m_ControllerSchemeIndex = -1;
    public InputControlScheme ControllerScheme
    {
        get
        {
            if (m_ControllerSchemeIndex == -1) m_ControllerSchemeIndex = asset.FindControlSchemeIndex("Controller");
            return asset.controlSchemes[m_ControllerSchemeIndex];
        }
    }
    public interface IIngameActions
    {
        void OnWalk(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
    }
}
