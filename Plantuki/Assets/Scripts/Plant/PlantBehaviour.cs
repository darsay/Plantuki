/*
 * Plant atributes and functions to modify them
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantBehaviour : MonoBehaviour
{
    public static PlantBehaviour instance;

    // Plant needs with getters and setters
    public float wetness { get; private set; }
    public float satiety { get; private set; }
    public float cleanliness { get; private set; }
    public float lightness { get; private set; } // Light needs to be around 60 to be OK

    private void Awake()
    {
        instance = this;

        // Se inicializa a 100, deberia cambiarse para guardar el estado entre partidas
       if (PlayerPrefs.HasKey("wetness"))
       {
           this.wetness = PlayerPrefs.GetFloat("wetness");
           this.satiety = PlayerPrefs.GetFloat("satiety");
           this.cleanliness =PlayerPrefs.GetFloat("cleanliness");
           this.lightness = PlayerPrefs.GetFloat("lightness");
       }
       else
       {
            this.wetness = 100;
            this.satiety =  100;
            this.cleanliness = 100;
            this.lightness =  70;
            
            Notifications.SharedInstance.sendNotification("¡Plantuki tiene sed!", "vuelve pronto", 0, wetness/100*1440);
            Notifications.SharedInstance.sendNotification("¡La tripita de Plantuki ruge!", "vuelve pronto", 1, satiety/100*1440);
            Notifications.SharedInstance.sendNotification("¡A Plantuki le hace falta un baño!", "vuelve pronto", 2, cleanliness/100*1440);
       }
       
       GiveClean(0);
       GiveFood(0);
       GiveLight(0);
       GiveWater(0);
        
    }

    /////////////////////////////////////////////////////////////
    /// INCREASE STATS
    /////////////////////////////////////////////////////////////
    #region  Increase stats
    public void GiveWater(float f)
    {
        wetness += f;
        wetness = Mathf.Clamp(wetness, f, 100);
        
        // if (wetness > 100)
        // {
        //     wetness = 100;
        // }

        Notifications.SharedInstance.cancelNotification(0);
        Notifications.SharedInstance.sendNotification("¡Plantuki tiene sed!", "vuelve pronto", 0, wetness/100*1440);
    }

    public void GiveFood(float f)
    {
        satiety += f;
        satiety = Mathf.Clamp(satiety, f, 100);
        Notifications.SharedInstance.cancelNotification(1);
        Notifications.SharedInstance.sendNotification("¡La tripita de Plantuki ruge!", "vuelve pronto", 1, satiety/100*1440);
    }

    public void GiveClean(float f)
    {
        cleanliness += f;
        cleanliness = Mathf.Clamp(cleanliness, f, 100);
        
        Notifications.SharedInstance.cancelNotification(2);
        Notifications.SharedInstance.sendNotification("¡A Plantuki le hace falta un baño!", "vuelve pronto", 2, cleanliness/100*1440);
    }

    public void GiveLight(float f)
    {
        lightness += f;
        lightness = Mathf.Clamp(lightness, f, 100);
        
    }
    #endregion


    /////////////////////////////////////////////////////////////
    /// DECREASE STATS
    /////////////////////////////////////////////////////////////
    #region  Decrease stats
    public void DecreaseAll(float wet, float sat, float clean, float light)
    {
        wetness = wetness - wet > 0 ? wetness - wet : 0;
        
        satiety = satiety - sat > 0 ? satiety - sat : 0;
        
        cleanliness = cleanliness - clean > 0 ? cleanliness - clean : 0;
        
        lightness = lightness - light > 0 ? lightness - light : 0;
    }

    public void MakeDry(float f)
    {
        wetness = wetness - f > 0 ? wetness - f : 0;
        
        PlayerPrefs.SetFloat("wetness", wetness);
        PlayerPrefs.Save();
            
    }

    public void MakeHungry(float f)
    {
        satiety = satiety - f > 0 ? satiety - f : 0;
        
        PlayerPrefs.SetFloat("satiety", satiety);
        PlayerPrefs.Save();
    }

    public void MakeDirty(float f)
    {
        cleanliness = cleanliness - f > 0 ? cleanliness - f : 0;
        
        PlayerPrefs.SetFloat("cleanliness", cleanliness);
        PlayerPrefs.Save();
    }


    public void MakeDark(float f)
    {
        lightness = lightness - f > 0 ? lightness - f : 0;
        
        PlayerPrefs.SetFloat("lightness", lightness);
        PlayerPrefs.Save();

        
    }
    #endregion
}
