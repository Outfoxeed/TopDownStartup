using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using Game.Runtime;
using Game.Runtime.Guns.Factory;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class PlayerBrain : MonoBehaviour
{
    [SerializeField, BoxGroup("Dependencies")] EntityMovement _movement;
    public Shooter Shooter { get; private set; }

    [SerializeField, BoxGroup("Input")] InputActionProperty _moveInput;
    [SerializeField, BoxGroup("Input")] InputActionProperty _attackInput;


    [Inject]
    public void Construct(IGunFactory gunFactory)
    {
        Shooter = new Shooter(transform, gunFactory);
    }
    
    private void Start()
    {
        // Move
        _moveInput.action.started += UpdateMove;
        _moveInput.action.performed += UpdateMove;
        _moveInput.action.canceled += StopMove;
        // Attack
        //_attackInput.action.started += Attack;
    }

    private void OnDestroy()
    {
        // Move
        _moveInput.action.started -= UpdateMove;
        _moveInput.action.performed -= UpdateMove;
        _moveInput.action.canceled -= StopMove;
    }


    private void UpdateMove(InputAction.CallbackContext obj)
    {
        _movement.Move(obj.ReadValue<Vector2>().normalized);
    }
    private void StopMove(InputAction.CallbackContext obj)
    {
        _movement.Move(Vector2.zero);
    }
}
