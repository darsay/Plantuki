using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class PlantController : MonoBehaviour
{
    private enum WindowState { OPEN, CLOSED, MIDOPEN}

    public static PlantController instance;
    // Timers, in seconds
    [SerializeField] private float checkStatusSeconds = 1f;
    [SerializeField] private float lowerStatsSeconds = 10f; // Seconds to lower one point of any stat

    [SerializeField] private float amoutChangedStats = 0.1f;

    [SerializeField] private int pointsChangedPerHourWhileOut = 1;

    private PlantAnimations plantAnimations;// Points changed per hour while NOT in the app

    [SerializeField] private WindowBlind windowBlind;

    private void Awake() {
        //PlayerPrefs.DeleteAll();
        instance = this;

        plantAnimations = FindObjectOfType<PlantAnimations>();
    }
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

    public int CheckTimeSinceLastGame()
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

    private void ChangeLightning(float amount)
    {
        // Changes Plantuki's light depending on a value and amount given
       
        float windowY = windowBlind.blind.transform.localPosition.y;
        
        if(windowY > 0.5)
        {
            // Full light
            PlantBehaviour.instance.GiveLight(amount);
            windowBlind.image.sprite = windowBlind.sprites[2];
        }
        else if(windowY > 0.2)
        {
            // Medium light
            PlantBehaviour.instance.MakeDark(amount/10);
            windowBlind.image.sprite = windowBlind.sprites[1];
        }
        else
        {
            // Low light
            PlantBehaviour.instance.MakeDark(amount);
            windowBlind.image.sprite = windowBlind.sprites[0];
        }
    }
    

    /*
    *      CHECK STATS
    */
    private void CheckStats() {
        plantAnimations.sad = false;
        CheckSatiety();
        CheckWetness();
        CheckCleanliness();
        CheckLightness();
        plantAnimations.ChangeIdle();
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

        if (PlantBehaviour.instance.satiety <= 20) {
            plantAnimations.sad = true;
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
        
        if (PlantBehaviour.instance.wetness <= 20) {
            plantAnimations.sad = true;
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
        
        if (PlantBehaviour.instance.cleanliness <= 10) {
            plantAnimations.sad = true;
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
        
        if (PlantBehaviour.instance.lightness >= 80 || PlantBehaviour.instance.lightness <= 20) {
            plantAnimations.sad = true;
        }
    }
}
