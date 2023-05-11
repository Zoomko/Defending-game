using System;
using System.Linq;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class InputService
{
    private InputActions _inputActions;

    public Vector2 Move => _inputActions.Player.Move.ReadValue<Vector2>();
    public Vector2 MousePosition => _inputActions.Player.MousePosition.ReadValue<Vector2>();

    public bool IsAttacking;

    public Action Attacked;
    public Action SavedProgress;
    public Action LoadedProgress;

    public InputService()
    {
        _inputActions = new InputActions();
        _inputActions.Enable();
        AssignEvents();
    }

    private void AssignEvents()
    {
        _inputActions.Player.Attack.performed += delegate (CallbackContext callback) { IsAttacking = true; Attacked?.Invoke(); };
        _inputActions.Player.Attack.canceled += (callback) => IsAttacking = false;
        _inputActions.Player.Save.performed += (callback) => SavedProgress?.Invoke();
        _inputActions.Player.Load.performed += (callback) => LoadedProgress?.Invoke();
    }
}
