using Assets.CodeBase.Services;
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
    private RaycastService _raycatsService;
    private IStaticDataService _staticDataService;  

    private float _speed;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }
    [Inject]
    public void Contructor(InputService inputService, RaycastService raycatsService, IStaticDataService staticDataService)
    {
        _inputService = inputService;
        _raycatsService = raycatsService;
        _staticDataService = staticDataService;
    }
    private void Start()
    {
        _speed = _staticDataService.PlayerStaticData.Speed;
    }
    private void Update()
    {
        Move();
        RotateToMousePoint();
    }

    private void Move()
    {
        var movementInput = new Vector3(_inputService.Move.x, 0, _inputService.Move.y);
        var movementVector = movementInput * _speed * Time.deltaTime;     
        movementVector += Physics.gravity;
        _characterController.Move(movementVector);
    }
    private void RotateToMousePoint()
    {
        if(_raycatsService.RaycastFromMousePosition(out var raycastHit))
        {
            var raycastPoint = raycastHit.point;
            var vectorToPoint = raycastPoint - transform.position;
            var projectedVectorToPoint = Vector3.ProjectOnPlane(vectorToPoint, Vector3.up).normalized;
            transform.forward = projectedVectorToPoint;
        }
    }
}
