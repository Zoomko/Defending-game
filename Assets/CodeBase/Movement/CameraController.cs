using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Vector3 _rotation;
	[SerializeField]
	private float _distance;   

    private Transform _cameraTransform;
    private void Awake()
    {
		_cameraTransform = Camera.main.transform;        
    }	
    private void LateUpdate()
    {
        var rotation = Quaternion.Euler(_rotation);
        _cameraTransform.position = transform.position;
        _cameraTransform.position += rotation * (Vector3.forward * _distance);
        _cameraTransform.LookAt(transform.position);  
    }
}
