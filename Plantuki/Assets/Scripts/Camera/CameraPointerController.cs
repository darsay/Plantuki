using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using DigitalRubyShared;
using UnityEngine;
using UnityEngine.Events;
using TouchPhase = UnityEngine.TouchPhase;

[RequireComponent(typeof(CameraPointerBehaviour))]
public class CameraPointerController : MonoBehaviour {
    public UnityEvent OnObjectSelected;
    public UnityEvent OnObjectDeselected;
    private CameraPointerBehaviour _cameraPointerBehaviour;
    private Vector3 originalPos;
    
   [SerializeField] private GameObject _beginningtarget;
   [SerializeField] private GameObject _endTarget;
   private FingersRotateCameraComponentScript _cameraRotator;
   
   

    private void Awake() {
        _cameraPointerBehaviour = GetComponent<CameraPointerBehaviour>();
        _cameraRotator = GetComponent<FingersRotateCameraComponentScript>();
        originalPos = transform.position;
    }

    private void OnEnable() {
        OnObjectDeselected.AddListener(BackToOriginal);
        OnObjectSelected.AddListener(() => _cameraRotator.enabled = false);
    }

    private void OnDisable() {
        OnObjectDeselected.RemoveListener(BackToOriginal);
        OnObjectSelected.RemoveListener(() => _cameraRotator.enabled = false);
    }

    private void Update() {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) {
            _beginningtarget = _cameraPointerBehaviour.CastRay(Camera.main.ScreenPointToRay(Input.GetTouch(0).position));
        }
        
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended) {
            _endTarget = _cameraPointerBehaviour.CastRay(Camera.main.ScreenPointToRay(Input.GetTouch(0).position));
            
            if (_beginningtarget == _endTarget && _endTarget!=null) {
                OnObjectSelected.Invoke();
                _cameraPointerBehaviour.MoveToPOI(_endTarget.GetComponent<SelectableObject>().GetPOI());
            }

            _beginningtarget = null;
            _endTarget = null;
        }

        
    }

    public void BackToOriginal() {
        _cameraPointerBehaviour.GoBack(originalPos, _cameraRotator);
    }

    public void OnDeselected() {
        OnObjectDeselected.Invoke();
    }
}
