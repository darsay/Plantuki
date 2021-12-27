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

    [SerializeField] private Sprite volume;
    [SerializeField] private Sprite back;
    private Image spriteRenderer;

    private void Awake() {
        _button = GetComponent<Button>();
        finger = FindObjectOfType<FingersRotateCameraComponentScript>();
        spriteRenderer = GetComponent<Image>();
    }

    private void OnEnable() {
        _button.onClick.AddListener(HideShowMenu);
    }

    private void OnDisable() {
        _button.onClick.RemoveListener(HideShowMenu);
    }

    void HideShowMenu() {
        if (_audioMenu.activeSelf) {
            _audioMenu.GetComponent<DisableAnim>().DisablePlay();
            spriteRenderer.sprite = volume;
            finger.enabled = true;
        }
        else {
            _audioMenu.SetActive(true);
            spriteRenderer.sprite = back;
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
