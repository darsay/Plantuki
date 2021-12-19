using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsManager : MonoBehaviour
{

    public static CoinsManager instance;

    private void Awake()
    {
        instance = this;
    }

    public int myCoins=1000;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void modifyCoins(int coins)
    {
        myCoins += coins;
    }
}
