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

    private void Start()
    {
        instance = this;

        // Se inicializa a 100, deber�a cambiarse para guardar el estado entre partidas
        this.wetness = 100f;
        this.satiety = 100f;
        this.cleanliness = 100f;
        this.lightness = 100f;
    }

    /////////////////////////////////////////////////////////////
    /// INCREASE STATS
    /////////////////////////////////////////////////////////////
    #region  Increase stats
    public void GiveWater(float f)
    {
        
            wetness += f;
            if (wetness > 100)
            {
                wetness = 100;
            }
            
            Notifications.SharedInstance.cancelNotification(0);
            Notifications.SharedInstance.sendNotification("Tiene sed", "vuelve pronto", 0, wetness/100);
        
        

    }
    
    public void GiveFood(float f)
    {
        if (satiety + f <= 100)
            satiety += f;
    }
    public void GiveClean(float f)
    {
        if (cleanliness + f <= 100)
            cleanliness += f;
    }

    public void GiveLight(float f)
    {
        if (lightness + f <= 100)
            lightness += f;
    }
    #endregion


    /////////////////////////////////////////////////////////////
    /// DECREASE STATS
    /////////////////////////////////////////////////////////////
    #region  Decrease stats
    public void DecreaseAll(float wet, float sat, float clean, float light)
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

    public void MakeDry(float f)
    {
        if (wetness >= f)
        {
            wetness -= f;
            UiManager.SharedInstance.wetness.text = wetness.ToString();
        }
            
    }

    public void MakeHungry(float f)
    {
        if (satiety >= f)
            satiety -= f;
    }

    public void MakeDirty(float f)
    {
        if (cleanliness >= f)
            cleanliness -= f;
    }


    public void MakeDark(float f)
    {
        if (lightness >= f)
            lightness -= f;
    }
    #endregion
}
