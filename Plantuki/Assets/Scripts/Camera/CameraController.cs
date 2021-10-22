using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(CameraBehaviour))]
public class CameraController : MonoBehaviour{
    [SerializeField] private bool isRotationEnabled;
    
    private float previousTouchPoint;
    private float currentTouch;
    private CameraBehaviour _cameraBehaviour;

    private void Awake() {
        _cameraBehaviour = GetComponent<CameraBehaviour>();
    }

    private void LateUpdate() {
        if (!isRotationEnabled) return;
        
        if (Input.GetMouseButtonDown(0)) {
            previousTouchPoint = Input.mousePosition.x;
        }

        if (Input.GetMouseButton(0)) {
            currentTouch = Input.mousePosition.x;
            
            _cameraBehaviour.RotateCamera(previousTouchPoint, currentTouch);
            previousTouchPoint = currentTouch;
        }
        else {
            _cameraBehaviour.DecelerateCamera();
        }

        

    }
}
