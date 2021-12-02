using System;
using System.Collections;
using System.Collections.Generic;
using DigitalRubyShared;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioMenu : MonoBehaviour {
    [SerializeField] private Slider masterSlider;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;

    [SerializeField] private AudioMixer mixer;

    private FingersRotateCameraComponentScript rotator;

    private void Awake() {
        rotator = FindObjectOfType<FingersRotateCameraComponentScript>();
    }

    private void OnEnable() {
        rotator.enabled = false;
    }

    private void OnDisable() {
        rotator.enabled = true;
    }

    private void Update() {
        mixer.SetFloat("MasterVolume", masterSlider.value);
        mixer.SetFloat("MusicVolume", musicSlider.value);
        mixer.SetFloat("SfxVolume", sfxSlider.value);
    }
}
