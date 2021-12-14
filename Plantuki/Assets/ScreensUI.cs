using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreensUI : MonoBehaviour {
    private CameraPointerController cameraPointerController;
    
    private void Awake() {
        cameraPointerController = FindObjectOfType<CameraPointerController>();
        cameraPointerController.OnObjectDeselected.AddListener(DeactivateAll);
    }

    public void DeactivateAll() {
        foreach (Transform t in transform) {
            t.gameObject.SetActive(false);
        }
    }
}
