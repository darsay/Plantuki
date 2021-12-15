using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class PlantController : MonoBehaviour
{
    private enum WindowState { OPEN, CLOSED, MIDOPEN}

    // Timers, in seconds
    [SerializeField] private float checkStatusSeconds = 1f;
    [SerializeField] private float lowerStatsSeconds = 10f; // Seconds to lower one point of any stat

    [SerializeField] private int amoutChangedStats = 1;

    [SerializeField] private int pointsChangedPerHourWhileOut = 1;   // Points changed per hour while NOT in the app


    private void Start() 
    {
        // Functions invoked every x seconds.
        InvokeRepeating("CheckStats", 0, checkStatusSeconds); 
        InvokeRepeating("ChangeStats", 0, lowerStatsSeconds);

        // Stats changing on game start
        LowerStatsBasedOnLastGame(CheckTimeSinceLastGame());
    }

    /*
     *    CHANGE STATS (for any reason)
     */
    #region Lower stats since last game
    private void LowerStatsBasedOnLastGame(int seconds)
    {
        float changeFactor = pointsChangedPerHourWhileOut/60; 

        int amount = Mathf.RoundToInt(changeFactor * seconds); // Rounds the amount to integer
        PlantBehaviour.instance.MakeDry(amount);
        PlantBehaviour.instance.MakeHungry(amount);
        PlantBehaviour.instance.MakeDirty(amount);

        //  TO BE IMPLEMENTED!!!
        ChangeLightning(amount);
    }

    private int CheckTimeSinceLastGame()
    {
        // Checks the time passed since the player last played Plantuki
        // and lowers the stats depending on it.

        string closedtime = PlayerPrefs.GetString("closed-time");
        
        TimeSpan timeSpan = new TimeSpan();
        DateTime now = new DateTime();
        now = DateTime.UtcNow;

        DateTime lastClosedTime = Convert.ToDateTime(closedtime);

        timeSpan = now - lastClosedTime;

        int totalSecondsSinceLastGame = (int) Mathf.Round( (float)timeSpan.TotalSeconds );
        Debug.Log("Seconds passed since last game: " + totalSecondsSinceLastGame);

        return totalSecondsSinceLastGame;
    }

    void OnApplicationQuit()
    {
        // Stores the current time (used for the next game start)
        DateTime dateTime = DateTime.UtcNow;

        PlayerPrefs.SetString("closed-time", dateTime.ToString());
        Debug.Log("Application ended in " + dateTime);
    }
    #endregion

    #region Lower stats while in the game
    
    private void ChangeStats()
    {
        // Changes Plantuki's stats each x time.
        PlantBehaviour.instance.MakeHungry(amoutChangedStats);
        PlantBehaviour.instance.MakeDry(amoutChangedStats);
        PlantBehaviour.instance.MakeDirty(amoutChangedStats);

        //  Changes the light based on stats
        ChangeLightning(amoutChangedStats);
    }

    #endregion

    private void ChangeLightning(int amount)
    {
        // Changes Plantuki's light depending on a value and amount given
        GameObject window = GameObject.Find("Blind"); // Important, name of the gameobject!!
        float windowY = window.transform.localPosition.y;
        
        if(windowY > 0.5)
        {
            // Full light
            PlantBehaviour.instance.GiveLight(amount);
        }
        else if(windowY > 0.2)
        {
            // Medium light
            PlantBehaviour.instance.MakeDark(amount/10);
        }
        else
        {
            // Low light
            PlantBehaviour.instance.MakeDark(amount);
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
            case 100:
                Debug.Log("Your plant is full");
                break;
            case 50:
                Debug.Log("Your plant is starting to feel hungry");
                break;
            case 15:
                Debug.Log("Your plant is hungry");
                break;
            case 5:
                Debug.Log("Your plant starving to death!");
                break;
            case 0:
                Debug.Log("Your plant starved.");
                break;
        }
    }
    private void CheckWetness()
    {
        switch (PlantBehaviour.instance.wetness)
        {
            case 100:
                Debug.Log("Your plant is wet and happy");
                break;
            case 50:
                Debug.Log("Your plant is starting to feel thirsty");
                break;
            case 15:
                Debug.Log("Your plant is thirsty!");
                break;
            case 5:
                Debug.Log("Your plant is VERY thirsty!");
                break;
            case 0:
                Debug.Log("Your plant died of thirst.");
                break;
        }
    }
    private void CheckCleanliness()
    {
        switch (PlantBehaviour.instance.cleanliness)
        {
            case 100:
                Debug.Log("Your plant is clean");
                break;
            case 50:
                Debug.Log("Your plant is slightly dirty");
                break;
            case 15:
                Debug.Log("Your plant is dirty!");
                break;
            case 5:
                Debug.Log("Your plant really needs a cleanup");
                break;
        }
    }
    private void CheckLightness()
    {
        switch (PlantBehaviour.instance.lightness)
        {
            case 100:
                Debug.Log("Your plant has too much light");
                break;
            case 50:
                Debug.Log("Your plant is correctly iluminated");
                break;
            case 15:
                Debug.Log("Your plant needs light!");
                break;
            case 5:
                Debug.Log("Your plant is living in darkness");
                break;
        }
    }
}
