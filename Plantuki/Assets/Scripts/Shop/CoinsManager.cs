using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinsManager : MonoBehaviour
{

    public static CoinsManager instance;

    public int myCoins = 1000;
    [SerializeField] private GameObject CoinsTMP;
    private int coinsPerHourSinceLastGame = 5000;
    private float upgradeCoinsOffset = 5f; // Seconds since the game started to call the function. Only used once
    private float upgradeCoinsSeconds = 10f; // Interval in seconds to call the function every time

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        
        CoinsTMP = GameObject.Find("MyCoins");
    }

    
    // Start is called before the first frame update
    void Start()
    {        
        if (PlayerPrefs.HasKey("coins"))
        {
            myCoins = PlayerPrefs.GetInt("coins");
            GiveCoinsBasedOnLastGame();
        } 

        InvokeRepeating("UpgradeCoins", upgradeCoinsOffset, upgradeCoinsSeconds); 
       
    }

    private void GiveCoinsBasedOnLastGame()
    {
        // Gives coins based on the time passed since the last game
        int coins = 0;
        int seconds = PlantController.instance.CheckTimeSinceLastGame();

        coins = Mathf.RoundToInt((seconds/60)/60) * coinsPerHourSinceLastGame;  // coins per hour

        modifyCoins(coins);
    }

    private void UpgradeCoins()
    {
        // Gives coins to the player based on Plantuki's stats
        //  1 coin per stat taken care of. 

        int coins = 0;

        if(PlantBehaviour.instance.satiety > 75)
            coins++;

        if(PlantBehaviour.instance.wetness > 75)
            coins++;

        if(PlantBehaviour.instance.cleanliness > 75)
            coins++;

        if(PlantBehaviour.instance.lightness > 35 &&
             PlantBehaviour.instance.lightness < 75)
            coins++;

        modifyCoins(coins);
    }

    public void modifyCoins(int coins)
    {
        myCoins += coins;
        setCoins();
        PlayerPrefs.SetInt("coins", myCoins);
        PlayerPrefs.Save();
    }

    public void setCoins()
    {
        if(CoinsTMP!=null)
        CoinsTMP.GetComponent<TextMeshProUGUI>().text = myCoins.ToString();
    }
}
