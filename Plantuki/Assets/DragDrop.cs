using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IDragHandler, IPointerDownHandler, IBeginDragHandler, IEndDragHandler {
    public enum Type {
        food,
        soap,
        water
    }
    
    private Vector2 initialPos;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    public Type objectType;

    [SerializeField] private Canvas canvas;

    private PlantAnimations plantAnimations;

    private void Awake() {
        rectTransform = GetComponent<RectTransform>();
        initialPos = rectTransform.anchoredPosition;
        canvasGroup = GetComponent<CanvasGroup>();

        plantAnimations = FindObjectOfType<PlantAnimations>();
    }


    public void OnPointerDown(PointerEventData eventData) {
        throw new NotImplementedException();
    }

    public void OnEndDrag(PointerEventData eventData) {
        rectTransform.anchoredPosition = initialPos;
        
        canvasGroup.alpha = 1;
        canvasGroup.blocksRaycasts = true;
    }

    public void OnBeginDrag(PointerEventData eventData) {
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData) {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }
}
