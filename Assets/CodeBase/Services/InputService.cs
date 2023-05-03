using System;
using UnityEngine;

public class InputService
{
    private InputActions _inputActions;

    public Vector2 Move => _inputActions.Player.Move.ReadValue<Vector2>();
    public Vector2 MousePosition => _inputActions.Player.MousePosition.ReadValue<Vector2>();

    public Action Attacked;

    public InputService()
    {
        _inputActions = new InputActions();
        _inputActions.Enable();
        AssignEvents();
    }

    private void AssignEvents()
    {
        _inputActions.Player.Attack.performed += (callback) => Attacked?.Invoke();
    }
}
