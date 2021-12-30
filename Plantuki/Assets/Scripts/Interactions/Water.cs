using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour {
    private DragDrop dragDrop;

    private void Awake() {
        dragDrop = GetComponent<DragDrop>();
    }
    
    
}
