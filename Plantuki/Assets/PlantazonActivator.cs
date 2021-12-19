using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantazonActivator : MonoBehaviour {
    
    [SerializeField] private float startTime;
    [SerializeField] private GameObject plantazonUI;
    

    public void SetUpPlantazon() {
        StartCoroutine(StartPlantazon(startTime));
    }
    IEnumerator StartPlantazon(float t) {
        yield return new WaitForSeconds(t);
        plantazonUI.SetActive(true);
    }
}
