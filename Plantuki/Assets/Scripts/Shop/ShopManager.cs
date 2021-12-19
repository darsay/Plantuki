using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShopManager : MonoBehaviour
{
    public static ShopManager instance;

    public Dictionary<string,int> availablesItemsPrices = new Dictionary<string, int>();

    public List<GameObject> availableItems;

    private GameObject shopContent;
    

    private void Awake()
    {
        instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        shopContent = GameObject.Find("Content");
        checkItemsOwned();
        addItems();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void addItems()
    {
        availablesItemsPrices.Add("cowboyHat", 200);
        availablesItemsPrices.Add("diadema", 300);
        availablesItemsPrices.Add("crown", 2500);
        
        availablesItemsPrices.Add("modernPot", 220);
        availablesItemsPrices.Add("pipelinePot", 600);
        availablesItemsPrices.Add("andalucianPot", 420);
        
        availablesItemsPrices.Add("piranaSkin", 550);
        availablesItemsPrices.Add("flamencoSkin", 400);
        availablesItemsPrices.Add("tangerineSkin", 300);
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


    public void showAll()
    {
        foreach (Transform item in shopContent.transform)
        {
            item.gameObject.SetActive(true);
        }
    }
    
    public void showHats()
    {
        foreach (Transform item in shopContent.transform)
        {
            if (item.gameObject.CompareTag("Hats"))
            {
                item.gameObject.SetActive(true);
            }
            else
            {
                item.gameObject.SetActive(false);
            }
        }
    }
    
    public void showSkins()
    {
        foreach (Transform item in shopContent.transform)
        {
            if (item.gameObject.CompareTag("Skins"))
            {
                item.gameObject.SetActive(true);
            }
            else
            {
                item.gameObject.SetActive(false);
            }
        }
    }
    
    public void showPots()
    {
        foreach (Transform item in shopContent.transform)
        {
            if (item.gameObject.CompareTag("Pots"))
            {
                item.gameObject.SetActive(true);
            }
            else
            {
                item.gameObject.SetActive(false);
            }
        }
    }

    public void checkItemsOwned()
    {
        print("Checking");
        foreach (Transform item in shopContent.transform)
        {
            if (PlantItemsManager.instance.myItems.Contains(item.name))
            {
                item.GetChild(0).gameObject.SetActive(true);
            }
        }
    }

    public void buyItem(string ItemName)
    {
        if (CoinsManager.instance.myCoins >= availablesItemsPrices[ItemName])
        {
            PlantItemsManager.instance.myItems.Add(ItemName);
            PlantItemsManager.instance.BuyItem(ItemName);
            checkItemsOwned();
            CoinsManager.instance.modifyCoins(-1*availablesItemsPrices[ItemName]);
            
        }
    }

}
