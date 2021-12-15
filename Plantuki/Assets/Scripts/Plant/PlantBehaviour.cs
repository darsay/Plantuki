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
    public int wetness { get; private set; }
    public int satiety { get; private set; }
    public int cleanliness { get; private set; }
    public int lightness { get; private set; } // Light needs to be around 60 to be OK

    private void Awake()
    {
        instance = this;

        // Se inicializa a 100, deberia cambiarse para guardar el estado entre partidas
        this.wetness = 100;
        this.satiety = 100;
        this.cleanliness = 100;
        this.lightness = 100;
    }

    /////////////////////////////////////////////////////////////
    /// INCREASE STATS
    /////////////////////////////////////////////////////////////
    #region  Increase stats
    public void GiveWater(int f)
    {
        wetness += f;
        wetness = Mathf.Clamp(wetness, f, 100);
        
        // if (wetness > 100)
        // {
        //     wetness = 100;
        // }

        Notifications.SharedInstance.cancelNotification(0);
        Notifications.SharedInstance.sendNotification("Tiene sed", "vuelve pronto", 0, wetness/100);
    }

    public void GiveFood(int f)
    {
        satiety += f;
        satiety = Mathf.Clamp(satiety, f, 100);
    }

    public void GiveClean(int f)
    {
        cleanliness += f;
        cleanliness = Mathf.Clamp(cleanliness, f, 100);
    }

    public void GiveLight(int f)
    {
        lightness += f;
        lightness = Mathf.Clamp(lightness, f, 100);
    }
    #endregion


    /////////////////////////////////////////////////////////////
    /// DECREASE STATS
    /////////////////////////////////////////////////////////////
    #region  Decrease stats
    public void DecreaseAll(int wet, int sat, int clean, int light)
    {
        if (wetness >= wet)
            wetness -= wet;

        if (satiety >= sat)
            satiety -= sat;

        if (cleanliness >= clean)
            cleanliness -= clean;

        if (lightness >= light)
            lightness -= light;
    }

    public void MakeDry(int f)
    {
        if (wetness >= f)
            wetness -= f;
            
    }

    public void MakeHungry(int f)
    {
        if (satiety >= f)
            satiety -= f;
    }

    public void MakeDirty(int f)
    {
        if (cleanliness >= f)
            cleanliness -= f;
    }


    public void MakeDark(int f)
    {
        if (lightness >= f)
        {
            lightness -= f;
        }
        
    }
    #endregion
}
