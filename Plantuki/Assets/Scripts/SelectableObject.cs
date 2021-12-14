using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SelectableObject : MonoBehaviour {
    public UnityEvent onSelected;
    
    [SerializeField] private Transform _pointOfInterest;


    public Transform GetPOI() {
        return _pointOfInterest;
    }
}
