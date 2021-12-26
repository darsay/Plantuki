using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantCustomization : MonoBehaviour {
    [SerializeField] private Plant[] plants;
    [SerializeField] private GameObject [] pots;
    [SerializeField] private GameObject [] hats;

    private int currentPlant = 0;
    private int currentPot = 0;
    private int currentHat = 0;

    private void Awake() {
        foreach (var p in plants) {
            p.gameObject.SetActive(false);
        }
        plants[currentPlant].gameObject.SetActive(true);
        
        foreach (var p in pots) {
            p.SetActive(false);
        }
        pots[currentPot].SetActive(true);

        hats = plants[currentPlant].hats;
        foreach (var h in hats) {
            h.SetActive(false);
        }
        hats[currentHat].SetActive(true);
    }


    public void NextPot() {
        pots[currentPot].SetActive(false);
        currentPot = (currentPot + 1) % pots.Length;
        pots[currentPot].SetActive(true);
    }
    
    public void PreviousPot() {
        pots[currentPot].SetActive(false);
        currentPot = currentPot - 1 < 0 ? pots.Length - 1 : currentPot - 1;
        pots[currentPot].SetActive(true);
    }
    
    public void NextPlant() {
        plants[currentPlant].gameObject.SetActive(false);
        currentPlant = (currentPlant + 1) % plants.Length;
        plants[currentPlant].gameObject.SetActive(true);
        hats = plants[currentPlant].hats;
        
        foreach (var h in hats) {
            h.SetActive(false);
        }
        hats[currentHat].SetActive(true);
    }
    
    public void PreviousPlant() {
        plants[currentPlant].gameObject.SetActive(false);
        currentPlant = currentPlant - 1 < 0 ? plants.Length - 1 : currentPlant - 1;
        plants[currentPlant].gameObject.SetActive(true);
        hats = plants[currentPlant].hats;
        
        foreach (var h in hats) {
            h.SetActive(false);
        }
        hats[currentHat].SetActive(true);
    }

    public void NextHat() {
        hats[currentHat].SetActive(false);
        currentHat = (currentHat + 1) % hats.Length;
        hats[currentHat].SetActive(true);
    }
    
    public void PreviousHat() {
        hats[currentHat].SetActive(false);
        currentHat = currentHat - 1 < 0 ? hats.Length - 1 : currentHat - 1;
        hats[currentHat].SetActive(true);
    }
}
