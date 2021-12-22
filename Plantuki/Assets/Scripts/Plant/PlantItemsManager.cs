using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantItemsManager : MonoBehaviour
{

    public static PlantItemsManager instance;
    public List<string> myItems = new List<string>();

    private void Awake() 
    {
        
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        checkItemsPrefs();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void checkItemsPrefs()
    {
        foreach (var item in ShopManager.instance.availablesItemsPrices)
        {
            if (PlayerPrefs.HasKey(item.Key))
            {
                myItems.Add(item.Key);
            }
        }
    }

    public void BuyItem(string name)
    {
        PlayerPrefs.SetString(name,"");
        PlayerPrefs.Save();
        
    }
}
