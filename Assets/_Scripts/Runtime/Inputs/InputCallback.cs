using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Game._Scripts.Runtime.Inputs
{
    public class InputCallback : MonoBehaviour
    {
        [SerializeField] private InputActionReference _inputActionRef;
        [SerializeField] private UnityEvent _callback;

        private void OnEnable()
        {
            _inputActionRef.action.performed += OnInputActionPerformed;
        }

        private void OnDisable()
        {
            _inputActionRef.action.performed -= OnInputActionPerformed;
        }

        private void OnInputActionPerformed(InputAction.CallbackContext obj)
        {
            _callback.Invoke();
        }
    }
}