using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantCustomization : MonoBehaviour {
    [SerializeField] private Plant[] plants;
    [SerializeField] private GameObject [] pots;
    [SerializeField] private GameObject [] hats;

    public int currentPlant;
    public int currentPot;
    public int currentHat;

    public List<int> hatsOwned = new List<int>();
    public List<int> plantsOwned = new List<int>();
    public List<int> potsOwned = new List<int>();

    public static PlantCustomization instance;
    private PlantAnimations plantAnimations;

    private void Start()
    {
        foreach (var p in plants) {
            p.gameObject.SetActive(false);
        }
        plants[plantsOwned[currentPlant]].gameObject.SetActive(true);
        plantAnimations.plantAnimator = plants[plantsOwned[currentPlant]].GetComponent<Animator>();
        
        foreach (var p in pots) {
            p.SetActive(false);
            Debug.Log("Xd");
        }
        pots[potsOwned[currentPot]].SetActive(true);

        hats = plants[plantsOwned[currentPlant]].hats;
        foreach (var h in hats) {
            h.SetActive(false);
        }
        hats[hatsOwned[currentHat]].SetActive(true);
        
        hatsOwned.Sort();
    }

    private void Awake()
    {
        instance = this;

        plantAnimations = GetComponent<PlantAnimations>();
        
        hatsOwned.Add(0);
        hatsOwned.Add(4);
        potsOwned.Add(0);
        plantsOwned.Add(0);
        
      //PlayerPrefs.DeleteKey("currentPlant");
      //PlayerPrefs.DeleteKey("currentPot");
      //PlayerPrefs.DeleteKey("currentHat");
        
       currentPlant = PlayerPrefs.GetInt("currentPlant");
       currentPot = PlayerPrefs.GetInt("currentPot");
       currentHat = PlayerPrefs.GetInt("currentHat");
        
        
        
        
    }


    public void NextPot() {
        pots[potsOwned[currentPot]].SetActive(false);
        currentPot = (currentPot + 1) % potsOwned.Count;
        Debug.Log(potsOwned[currentPot]);
        PlayerPrefs.SetInt("currentPot", currentPot);
        PlayerPrefs.Save();
        pots[potsOwned[currentPot]].SetActive(true);
        
    }
    
    public void PreviousPot() {
        pots[potsOwned[currentPot]].SetActive(false);
        currentPot = currentPot - 1 < 0 ? potsOwned.Count - 1 : currentPot - 1;
        Debug.Log(potsOwned[currentPot]);
        PlayerPrefs.SetInt("currentPot", currentPot);
        PlayerPrefs.Save();
        pots[potsOwned[currentPot]].SetActive(true);
    }
    
    public void NextPlant() {
        plants[plantsOwned[currentPlant]].gameObject.SetActive(false);
        currentPlant = (currentPlant + 1) % plantsOwned.Count;
        PlayerPrefs.SetInt("currentPlant", currentPlant);
        PlayerPrefs.Save();
        plants[plantsOwned[currentPlant]].gameObject.SetActive(true);
        hats = plants[plantsOwned[currentPlant]].hats;
        
        foreach (var h in hats) {
            h.SetActive(false);
        }
        hats[hatsOwned[currentHat]].SetActive(true);
        
        plantAnimations.plantAnimator = plants[plantsOwned[currentPlant]].GetComponent<Animator>();
    }
    
    public void PreviousPlant() {
        plants[plantsOwned[currentPlant]].gameObject.SetActive(false);
        currentPlant = currentPlant - 1 < 0 ? plantsOwned.Count - 1 : currentPlant - 1;
        PlayerPrefs.SetInt("currentPlant", currentPlant);
        PlayerPrefs.Save();
        plants[plantsOwned[currentPlant]].gameObject.SetActive(true);
        hats = plants[plantsOwned[currentPlant]].hats;
        
        foreach (var h in hats) {
            h.SetActive(false);
        }
        hats[hatsOwned[currentHat]].SetActive(true);
        
        plantAnimations.plantAnimator = plants[plantsOwned[currentPlant]].GetComponent<Animator>();
    }

    public void NextHat() {
        hats[hatsOwned[currentHat]].SetActive(false);
        currentHat = (currentHat + 1) % hatsOwned.Count;
        PlayerPrefs.SetInt("currentHat", currentHat);
        PlayerPrefs.Save();
        hats[hatsOwned[currentHat]].SetActive(true);
    }
    
    public void PreviousHat() {
        hats[hatsOwned[currentHat]].SetActive(false);
        currentHat = currentHat - 1 < 0 ? hatsOwned.Count - 1 : currentHat - 1;
        PlayerPrefs.SetInt("currentHat", currentHat);
        PlayerPrefs.Save();
        hats[hatsOwned[currentHat]].SetActive(true);
    }
}
