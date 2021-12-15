using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public static ShopManager instance;

    public Dictionary<string,int> availablesItemsPrices = new Dictionary<string, int>();

    public List<GameObject> availableItems;

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

    private void addItems()
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

    private List<GameObject> GetUnownedItems()
    {
        // Returns a list of the unowned items to show in the shop
        //  based on the list of total available items to buy

        // For this function to work, the GameObjects must have the same name as
        //  the names in the string list
        List<string> unownedName = PlantItemsManager.instance.myItems;
        List<GameObject> unowned = availableItems;
        
        for(int i = 0; i < unowned.Count; i++)
        {
            for(int j = 0; j < unownedName.Count; j++)
            {
                if(unowned[i].name.Equals(unownedName[j])) // If the items is already owned, delete it from the unowned list
                {
                    unowned.Remove(unowned[i]);
                    break;  // Exist the loop when removed
                }  
                    
            }
        }

        return unowned;
    }

}
