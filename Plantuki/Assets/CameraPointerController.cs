using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(CameraPointerBehaviour), typeof(CameraRotationBehaviour))]
public class CameraPointerController : MonoBehaviour {
    public UnityEvent OnObjectSelected;
    private CameraPointerBehaviour _cameraPointerBehaviour;
    private CameraRotationBehaviour _cameraRotationBehaviour;
    
   [SerializeField] private GameObject _beginningtarget;
   [SerializeField] private GameObject _endTarget;

    private void Awake() {
        _cameraPointerBehaviour = GetComponent<CameraPointerBehaviour>();
        _cameraRotationBehaviour = GetComponent<CameraRotationBehaviour>();
    }

    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            _beginningtarget = _cameraPointerBehaviour.CastRay(Camera.main.ScreenPointToRay(Input.mousePosition));
        }
        
        if (Input.GetMouseButtonUp(0)) {
            _endTarget = _cameraPointerBehaviour.CastRay(Camera.main.ScreenPointToRay(Input.mousePosition));
            
            if (_beginningtarget == _endTarget && _endTarget!=null) {
                OnObjectSelected.Invoke();
                _cameraPointerBehaviour.MoveToPOI(_endTarget.GetComponent<SelectableObject>().GetPOI());
            }

            _beginningtarget = null;
            _endTarget = null;
        }

        
    }
}
