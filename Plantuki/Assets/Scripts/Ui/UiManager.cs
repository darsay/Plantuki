using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    [SerializeField] private GameObject shopUI;
    [SerializeField] private GameObject mainRoomUI;
    [SerializeField] private GameObject settingsUI;
    [SerializeField] private GameObject inventoryUI;

    public TextMeshProUGUI wetness;

    public static UiManager SharedInstance;
    
    private void Awake()
    {
        if (SharedInstance == null)
        {
            SharedInstance = this;
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void openSettings()
    {
        settingsUI.SetActive(true);
    }

    public void closeSettings()
    {
        settingsUI.SetActive(false);
    }
    
    public void openShop()
    {
        shopUI.SetActive(true);
    }

    public void closeShop()
    {
        shopUI.SetActive(false);
    }
    
}
