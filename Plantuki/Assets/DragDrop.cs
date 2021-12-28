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
    public bool isDragging;

    [SerializeField] private Canvas canvas;

    private PlantAnimations plantAnimations;

    private void Awake() {
        rectTransform = GetComponent<RectTransform>();
        initialPos = rectTransform.anchoredPosition;
        canvasGroup = GetComponent<CanvasGroup>();

        plantAnimations = FindObjectOfType<PlantAnimations>();
    }


    public void OnPointerDown(PointerEventData eventData) {
        
    }

    public void OnEndDrag(PointerEventData eventData) {
        rectTransform.anchoredPosition = initialPos;
        
        canvasGroup.alpha = 1;
        canvasGroup.blocksRaycasts = true;

        isDragging = false;
    }

    public void OnBeginDrag(PointerEventData eventData) {
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
        isDragging = true;
    }

    public void OnDrag(PointerEventData eventData) {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }
}
