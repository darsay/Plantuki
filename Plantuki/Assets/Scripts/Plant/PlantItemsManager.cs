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
                if (item.Key.StartsWith("h"))
                {
                    PlantCustomization.instance.hatsOwned.Add(int.Parse(item.Key[1].ToString()));
                }else if (item.Key.StartsWith("p"))
                {
                    PlantCustomization.instance.plantsOwned.Add(int.Parse(item.Key[1].ToString()));
                }else if (item.Key.StartsWith("m"))
                {
                    PlantCustomization.instance.potsOwned.Add(int.Parse(item.Key[1].ToString()));
                }
            }
        }
    }

    public void BuyItem(string name)
    {
        PlayerPrefs.SetString(name,"");
        PlayerPrefs.Save();
        
    }
}
