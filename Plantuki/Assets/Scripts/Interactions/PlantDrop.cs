using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlantDrop : MonoBehaviour, IDropHandler {
    private PlantAnimations plantAnimations;
    [SerializeField] private AudioSource eatAudio;
    [SerializeField] private AudioSource waterAudio;
    [SerializeField] private AudioSource cleaningAudio;

    [SerializeField] private DragDrop water;
    [SerializeField] private DragDrop soap;
    private RectTransform soapRt;

    private bool isWatering;
    private bool isCleaning;

    private Vector2 previousPos;

    private void Awake() {
        plantAnimations = FindObjectOfType<PlantAnimations>();
        soapRt = soap.GetComponent<RectTransform>();
    }

    public void OnDrop(PointerEventData eventData) {
        if (eventData.pointerDrag != null) {
            var dragable = eventData.pointerDrag.GetComponent<DragDrop>();

            if (dragable.objectType == DragDrop.Type.food) {
                plantAnimations.Eat();
                eatAudio.Play();
                PlantBehaviour.instance.GiveFood(10);
            }
        }
    }


    private void Update() {
        if (!water.isDragging) {
            waterAudio.volume = 0;
            isWatering = false;
        }

        if (isWatering) {
            PlantBehaviour.instance.GiveWater(0.5f);
        }
        
        if (!soap.isDragging) {
            cleaningAudio.volume = 0;
            isCleaning = false;
        }

        if (isCleaning) {
            var delta = Mathf.Abs((soapRt.anchoredPosition - previousPos).magnitude)/30;
            PlantBehaviour.instance.GiveClean((int)delta);
            previousPos = soapRt.anchoredPosition;
            print($"delta: {delta}");
        }
        
        
        
        
    }

    public void WaterOver() {
        if (!water.isDragging) return;
        isWatering = true;
        waterAudio.volume = 1;

    }
    
    public void WaterOut() {
        if (!water.isDragging) return;
        isWatering = false;
        waterAudio.volume = 0;

    }
    
    public void SoapOver() {
        if (!soap.isDragging) return;
        isCleaning = true;
        cleaningAudio.volume = 1;
        previousPos = soap.GetComponent<RectTransform>().anchoredPosition;

    }
    
    public void SoapOut() {
        if (!soap.isDragging) return;
        isCleaning = false;
        cleaningAudio.volume = 0;

    }
}
