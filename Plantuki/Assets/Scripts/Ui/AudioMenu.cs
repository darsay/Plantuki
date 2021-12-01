using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioMenu : MonoBehaviour {
    [SerializeField] private Slider masterSlider;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;

    [SerializeField] private AudioMixer mixer;

    private void Update() {
        mixer.SetFloat("MasterVolume", masterSlider.value);
        mixer.SetFloat("MusicVolume", musicSlider.value);
        mixer.SetFloat("SfxVolume", sfxSlider.value);
    }
}
