using System;
using System.Collections;
using System.Collections.Generic;
using DigitalRubyShared;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class VolumeButton : MonoBehaviour {
    private Button _button;
    private FingersRotateCameraComponentScript finger;
    [SerializeField] private GameObject _audioMenu;

    [SerializeField] private float coolDown;

    private void Awake() {
        _button = GetComponent<Button>();
        finger = FindObjectOfType<FingersRotateCameraComponentScript>();
    }

    private void OnEnable() {
        _button.onClick.AddListener(HideShowMenu);
    }

    private void OnDisable() {
        _button.onClick.RemoveListener(HideShowMenu);
    }

    void HideShowMenu() {
        if (_audioMenu.activeSelf) {
            _audioMenu.GetComponent<DisableAnim>().DisableMenu();
            
            finger.enabled = true;
        }
        else {
            _audioMenu.SetActive(true);
            finger.enabled = false;
        }
        StartCoroutine(CoolDownPress(coolDown));
    }

    IEnumerator CoolDownPress(float c) {
        _button.enabled = false;
        yield return new WaitForSeconds(c);
        _button.enabled = true;
    }
}
