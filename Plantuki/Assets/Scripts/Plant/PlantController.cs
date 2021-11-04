using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class PlantController : MonoBehaviour
{
    DateTime dateTime; // Tests for storing the date & time

    // Timers, in seconds
    [SerializeField] private float checkStatusSeconds = 1f;
    [SerializeField] private float lowerStatsSeconds = 1f;

    [SerializeField] private float amoutLoweredStats = 1f;


    private void Start()
    {
        // Functions invoked every x seconds.
        InvokeRepeating("CheckStats", 0, checkStatusSeconds); 
        InvokeRepeating("LowerStats", 0, lowerStatsSeconds);
    }

   

    /*
     *    LOWER STATS (for any reason)
     */
    private void LowerStats()
    {
        // Lowers Plantuki's stats each x time.
        PlantBehaviour.instance.MakeHungry(amoutLoweredStats);
        PlantBehaviour.instance.MakeDry(amoutLoweredStats);
        PlantBehaviour.instance.MakeDirty(amoutLoweredStats);
        PlantBehaviour.instance.MakeDark(amoutLoweredStats);
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
            case 25f:
                Debug.Log("Your plant is hungry");
                break;
            case 3f:
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
            case 40f:
                Debug.Log("Your plant is starting to feel thirsty");
                break;
            case 10f:
                Debug.Log("Your plant is very thirsty!");
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
        }
    }
}
