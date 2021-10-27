using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(CameraRotationBehaviour))]
public class CameraRotationController : MonoBehaviour{
    [SerializeField] private bool isRotationEnabled;
    private CameraPointerController _cameraPointerController;
    
    private float _previousTouchPoint;
    private float _currentTouch;
    private CameraRotationBehaviour _cameraRotationBehaviour;

    private void Awake() {
        _cameraRotationBehaviour = GetComponent<CameraRotationBehaviour>();
        _cameraPointerController = GetComponent<CameraPointerController>();
    }

    private void OnEnable() {
        _cameraPointerController.OnObjectSelected.AddListener(DisableRotation);
    }

    private void LateUpdate() {
        if (!isRotationEnabled) return;
        
        if (Input.GetMouseButtonDown(0)) {
            _previousTouchPoint = Input.mousePosition.x;
        }

        if (Input.GetMouseButton(0)) {
            _currentTouch = Input.mousePosition.x;
            
            _cameraRotationBehaviour.RotateCamera(_previousTouchPoint, _currentTouch);
            _previousTouchPoint = _currentTouch;
        }
        else {
            _cameraRotationBehaviour.DecelerateCamera();
        }

        if (Input.GetMouseButtonUp(0)) {
            _cameraRotationBehaviour.StopScrolling();
        }
        
    }

    public void DisableRotation() {
        isRotationEnabled = false;
    }
    
    public void EnableRotation() {
        isRotationEnabled = true;
    }
}
