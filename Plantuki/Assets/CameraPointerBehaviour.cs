using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class CameraPointerBehaviour : MonoBehaviour {
    [SerializeField] private float tweenTime;



    public GameObject CastRay(Ray ray) {
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit)) {
            GameObject collided = hit.transform.gameObject;
            
            if (collided.TryGetComponent(out SelectableObject sO)) {
                return sO.gameObject;
            }

            return null;
        }

        return null;
    }

    public void MoveToPOI(Transform pOI) {
        transform.DOMove(pOI.position, 1);
        transform.DORotate(pOI.rotation.eulerAngles, 1);
    }
}
