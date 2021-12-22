using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinsManager : MonoBehaviour
{

    public static CoinsManager instance;
    [SerializeField] private GameObject CoinsTMP;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        
        CoinsTMP = GameObject.Find("MyCoins");
    }

    public int myCoins=1000;
    // Start is called before the first frame update
    void Start()
    {
        
        
        if (PlayerPrefs.HasKey("coins"))
        {
            myCoins = PlayerPrefs.GetInt("coins");
        }
        
       
    }

    // Update is called once per frame
    void Update()
    {
        
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
