using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;
using DigitalRubyShared;

public class CameraPointerBehaviour : MonoBehaviour {
    [SerializeField] private float tweenTime;
    [SerializeField] private Vector3 preTouchRotation;


    public GameObject CastRay(Ray ray) {
        RaycastHit hit;
        
        if (Physics.Raycast(ray, out hit)) {
            GameObject collided = hit.transform.gameObject;
            
            if (collided.TryGetComponent(out SelectableObject sO)) {
                preTouchRotation = transform.rotation.eulerAngles;
                return sO.gameObject;
            }

            return null;
        }

        return null;
    }

    public void MoveToPOI(Transform pOI) {
        transform.DOMove(pOI.position, tweenTime);
        transform.DORotate(pOI.rotation.eulerAngles, tweenTime);
    }
    
    public void GoBack(Vector3 originalPos, FingersRotateCameraComponentScript rotator) {
        transform.DOMove(originalPos, tweenTime);
        transform.DORotate(preTouchRotation, tweenTime).OnComplete(() => {
            rotator.enabled = true;
        });
    }
}
