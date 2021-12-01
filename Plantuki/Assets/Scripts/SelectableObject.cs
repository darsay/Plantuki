using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectableObject : MonoBehaviour
{
    [SerializeField] private Transform _pointOfInterest;


    public Transform GetPOI() {
        return _pointOfInterest;
    }
}
