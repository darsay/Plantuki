using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantAnimations : MonoBehaviour {
    public Animator plantAnimator;
    public bool sad;

    public void Eat() {
        plantAnimator.Play("eat", -1, 0);
    }

    public void ChangeIdle() {
        if (sad) {
            plantAnimator.SetBool("Sad", true);
        }
        else {
            plantAnimator.SetBool("Sad", false);
        }
    }
}
