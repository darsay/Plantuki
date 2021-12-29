using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    private Image progressImg;

    private PlantBehaviour plantBehaviour;

    [SerializeField] private Color[] colors;
    
    delegate void StatMeassuring();
    private StatMeassuring meassureUpdate;

    private float top = 0;
    private float bottom;


    private void Awake() {
        plantBehaviour = FindObjectOfType<PlantBehaviour>();
        progressImg = meassure.GetComponent<Image>();

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

        if (plantBehaviour.cleanliness < 20) {
            progressImg.color = colors[1];
        }else{
            progressImg.color = colors[0];
        }
        
    }

    void LightUpdate() {
        
        meassure.anchoredPosition = new Vector2(0,
            bottom + (-bottom) * plantBehaviour.lightness / 100);
        
        if (plantBehaviour.lightness < 20) {
            progressImg.color = colors[0];
            return;
        }
        
        if (plantBehaviour.lightness >80) {
            progressImg.color = colors[2];
            return;
        }
        
        progressImg.color = colors[1];

        
    }

    void HungerUpdate() {
       meassure.anchoredPosition = new Vector2(0,
           bottom + (-bottom) * plantBehaviour.satiety / 100);
       
       if (plantBehaviour.satiety < 20) {
           progressImg.color = colors[1];
       }else{
           progressImg.color = colors[0];
       }
    }

    void WaterUpdate() {
        
        meassure.anchoredPosition = new Vector2(0,
            bottom + (-bottom) * plantBehaviour.wetness / 100);
        
        if (plantBehaviour.wetness < 20) {
            progressImg.color = colors[1];
        }else{
            progressImg.color = colors[0];
        }
        
    }
    
    
}
