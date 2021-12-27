using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantAnimations : MonoBehaviour {
    public Animator plantAnimator;


    public void Eat() {
        plantAnimator.Play("eat", -1, 0);
    }
}
