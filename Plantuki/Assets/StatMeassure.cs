using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatMeassure : MonoBehaviour
{
    enum Stat {
        Light,
        Hunger,
        Water,
        Cleaning
    }

    [SerializeField] private Stat statToMeassure;
    
    [SerializeField]private RectTransform maskRt;
    [SerializeField]private RectTransform meassure;

    private PlantBehaviour plantBehaviour;
    
    delegate void StatMeassuring();
    private StatMeassuring meassureUpdate;

    private float top = 0;
    private float bottom;


    private void Awake() {
        plantBehaviour = FindObjectOfType<PlantBehaviour>();

        meassureUpdate = SelectStat(statToMeassure);
        bottom = -maskRt.rect.height;
    }


    private void Update() {
        meassureUpdate();
    }

    
    StatMeassuring SelectStat(Stat stat) {
        switch (stat) {
            case Stat.Cleaning:
                return CleanUpdate;
            
            case Stat.Light:
                return LightUpdate;

            case Stat.Hunger:
                return HungerUpdate;

            case Stat.Water:
                return WaterUpdate;

            default:
                return null;
        }
    }

    void CleanUpdate() {
        
        meassure.anchoredPosition = new Vector2(0,
            bottom + (-bottom) * plantBehaviour.cleanliness / 100);
    }

    void LightUpdate() {
        
        meassure.anchoredPosition = new Vector2(0,
            bottom + (-bottom) * plantBehaviour.lightness / 100);
    }

    void HungerUpdate() {
       meassure.anchoredPosition = new Vector2(0,
           bottom + (-bottom) * plantBehaviour.satiety / 100);
    }

    void WaterUpdate() {
        
        meassure.anchoredPosition = new Vector2(0,
            bottom + (-bottom) * plantBehaviour.wetness / 100);
        
    }
    
    
}
