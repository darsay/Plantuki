using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowBlind : MonoBehaviour {
    [SerializeField] public Transform blind;
    [SerializeField] private float top;
    [SerializeField] private float bottom;
    [SerializeField] private AudioSource audioSource;
    
    private Vector2 prevPos;

    private bool updatingBlind;

    [SerializeField] public Sprite[] sprites;
    [SerializeField] public Image image;
    

    private void Update() {


        if (Input.touchCount == 0) {
            audioSource.volume = 0;
            return;
        }
        
        audioSource.volume = 1;
        
        if (Input.GetTouch(0).phase == TouchPhase.Began) {
            updatingBlind = true;
            
        }
        
        if (Input.GetTouch(0).phase == TouchPhase.Ended) {
            updatingBlind = false;
        }
        
        if (updatingBlind) {
            UpdateBlind();
        }
    }

    void UpdateBlind() {
        var futureValue = blind.localPosition + Vector3.up * (Input.GetTouch(0).deltaPosition.y * 0.0001f);

        
        if (futureValue.y > top) {
            futureValue.y = top;
        }
        
        if (futureValue.y <bottom) {
            futureValue.y = bottom;
        }
        
        blind.localPosition = futureValue;
    }
    
    
    
}
