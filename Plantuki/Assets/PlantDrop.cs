using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlantDrop : MonoBehaviour, IDropHandler {
    private PlantAnimations plantAnimations;
    [SerializeField] private AudioSource eatAudio;

    private void Awake() {
        plantAnimations = FindObjectOfType<PlantAnimations>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDrop(PointerEventData eventData) {
        if (eventData.pointerDrag != null) {
            var dragable = eventData.pointerDrag.GetComponent<DragDrop>();

            if (dragable.objectType == DragDrop.Type.food) {
                plantAnimations.Eat();
                eatAudio.Play();
            }
        }
    }
}
