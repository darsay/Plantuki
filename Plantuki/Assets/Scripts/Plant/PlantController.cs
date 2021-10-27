using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class PlantController : MonoBehaviour
{
    DateTime dateTime;

    private const float CHECK_STATUS_TIMER = 1f;
    private const float LOWER_SATIETY_TIMER = 0.5f;


    private void Start()
    {
        StartCoroutine(MakeHungry(LOWER_SATIETY_TIMER));
        InvokeRepeating("CheckSatiety", CHECK_STATUS_TIMER, CHECK_STATUS_TIMER);
    }

    /*
     *      CHECK STATS
     */
    private void CheckSatiety()
    {
        switch(PlantBehaviour.instance.satiety)
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
                Debug.Log("Your plant starved");
                break;
        }
    }


    /*
     *      LOWER STATS (for any reason)
     */

    private IEnumerator MakeHungry(float points_lost)
    {
        yield return new WaitForSeconds(LOWER_SATIETY_TIMER);

        if(PlantBehaviour.instance.satiety > 0)
            PlantBehaviour.instance.satiety -= points_lost;
    }
}
