/*
 * Plant atributes and functions to modify them
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantBehaviour : MonoBehaviour
{
    public static PlantBehaviour instance;

    // Plant needs with getters and setters
    public float wetness { get; set; }
    public float satiety { get; set; }
    public float cleanliness { get; set; }
    public float lightness { get; set; }

    private void Start()
    {
        instance = this;

        this.wetness = 100f;
        this.satiety = 100f;
        this.cleanliness = 100f;
        this.lightness = 100f;
    }





}
