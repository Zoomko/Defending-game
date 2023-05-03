using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(CharacterController))]
public class MovementController : MonoBehaviour
{
    private CharacterController _characterController;
    private InputService _inputService;
    //Init this value with static data
    private float _speed = 10f;
    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }
    [Inject]
    public void Contructor(InputService inputService)
    {
        _inputService = inputService;
    }
    private void Update()
    {
        Move();  
    }

    private void Move()
    {
        var movementInput = new Vector3(_inputService.Move.x, 0, _inputService.Move.y);
        var movementVector = movementInput * _speed * Time.deltaTime;     
        movementVector += Physics.gravity;
        _characterController.Move(movementVector);
    }
}
