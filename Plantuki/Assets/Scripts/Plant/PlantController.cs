using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class PlantController : MonoBehaviour
{
    DateTime dateTime; // Tests for storing the date & time

    private enum LightConditions { LIGHT, DARK, NEUTRAL}

    // Timers, in seconds
    [SerializeField] private float checkStatusSeconds = 1f;
    [SerializeField] private float lowerStatsSeconds = 1f;

    [SerializeField] private float amoutLoweredStats = 1f;


    private void Start()
    {
        // Functions invoked every x seconds.
        InvokeRepeating("CheckStats", 0, checkStatusSeconds); 
        InvokeRepeating("LowerStats", 0, lowerStatsSeconds);

        CheckTimeSinceLastGame();
    }

    private void CheckTimeSinceLastGame()
    {
        // Checks the time passed since the player last played Plantuki
        // and lowers the stats depending on it.

        string closedtime = PlayerPrefs.GetString("closed-time");
        
        TimeSpan timeSpan = new TimeSpan();
        DateTime now = new DateTime();
        now = DateTime.UtcNow;

        DateTime lastClosedTime = Convert.ToDateTime(closedtime);

        timeSpan = now - lastClosedTime;
        Debug.Log(timeSpan);
    }
   
    void OnApplicationQuit()
    {
        dateTime = DateTime.UtcNow;

        PlayerPrefs.SetString("closed-time", dateTime.ToString());
        Debug.Log("Application ended in " + dateTime);
    }

    private int ConvertToSeconds(int hours, int minutes, int seconds)
    {
        int totalSecs = 0;
        totalSecs += seconds;
        totalSecs += minutes * 60;
        totalSecs += hours * 60 * 60;

        return totalSecs;
    }

    /*
     *    CHANGE STATS (for any reason)
     */
    private void LowerStats()
    {
        // Lowers Plantuki's stats each x time.
        PlantBehaviour.instance.MakeHungry(amoutLoweredStats);
        PlantBehaviour.instance.MakeDry(amoutLoweredStats);
        PlantBehaviour.instance.MakeDirty(amoutLoweredStats);
    }

    private void ChangeLightning(LightConditions value, float amount)
    {
        // Changes Plantuki's light depending on a value and amount given

        switch(value)
        {
            case LightConditions.LIGHT:
                PlantBehaviour.instance.GiveLight(amount);
                break;
            case LightConditions.DARK:
                PlantBehaviour.instance.MakeDark(amount);
                break;
            case LightConditions.NEUTRAL:
                // Do nothing
                break;
        }
    }

    

    /*
    *      CHECK STATS
    */
    private void CheckStats()
    {
        CheckSatiety();
        CheckWetness();
        CheckCleanliness();
        CheckLightness();
    }

    private void CheckSatiety()
    {
        switch (PlantBehaviour.instance.satiety)
        {
            case 100f:
                Debug.Log("Your plant is full");
                break;
            case 50f:
                Debug.Log("Your plant is starting to feel hungry");
                break;
            case 15f:
                Debug.Log("Your plant is hungry");
                break;
            case 5f:
                Debug.Log("Your plant starving to death!");
                break;
            case 0f:
                Debug.Log("Your plant starved.");
                break;
        }
    }
    private void CheckWetness()
    {
        switch (PlantBehaviour.instance.wetness)
        {
            case 100f:
                Debug.Log("Your plant is wet and happy");
                break;
            case 50f:
                Debug.Log("Your plant is starting to feel thirsty");
                break;
            case 15f:
                Debug.Log("Your plant is thirsty!");
                break;
            case 5f:
                Debug.Log("Your plant is VERY thirsty!");
                break;
            case 0f:
                Debug.Log("Your plant died of thirst.");
                break;
        }
    }
    private void CheckCleanliness()
    {
        switch (PlantBehaviour.instance.cleanliness)
        {
            case 100f:
                Debug.Log("Your plant is clean");
                break;
            case 50f:
                Debug.Log("Your plant is slightly dirty");
                break;
            case 15f:
                Debug.Log("Your plant is dirty!");
                break;
            case 5f:
                Debug.Log("Your plant really needs a cleanup");
                break;
        }
    }
    private void CheckLightness()
    {
        switch (PlantBehaviour.instance.lightness)
        {
            case 100f:
                Debug.Log("Your plant has too much light");
                break;
            case 50f:
                Debug.Log("Your plant is correctly iluminated");
                break;
            case 15f:
                Debug.Log("Your plant needs light!");
                break;
            case 5f:
                Debug.Log("Your plant is living in darkness");
                break;
        }
    }
}
