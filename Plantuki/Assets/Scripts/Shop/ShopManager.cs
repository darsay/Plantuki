using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public static ShopManager instance;

    public Dictionary<string,int> availablesItemsPrices = new Dictionary<string, int>();

    public List<GameObject> availableItems = new List<GameObject>();

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        addItems();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void addItems()
    {
        availablesItemsPrices.Add("cowboyHat", 10);
        availablesItemsPrices.Add("glasses", 20);
        availablesItemsPrices.Add("diadem", 50);
        availablesItemsPrices.Add("crown", 75);
        
        availablesItemsPrices.Add("chadPot", 10);
        availablesItemsPrices.Add("pipelinePot", 20);
        availablesItemsPrices.Add("andalucianPot", 50);
        
        availablesItemsPrices.Add("superMarioSkin", 150);
        availablesItemsPrices.Add("chungaSkin", 50);
        availablesItemsPrices.Add("guapingaSkin", 75);
        
        
    }
}
