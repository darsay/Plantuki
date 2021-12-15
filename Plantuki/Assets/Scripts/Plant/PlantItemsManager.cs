using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

public class PlantItemsManager : MonoBehaviour
{

    private List<string> myItems = new List<string>();

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

    public void addItem(string name)
    {
        PlayerPrefs.SetString(name,"");
        PlayerPrefs.Save();
    }
}
