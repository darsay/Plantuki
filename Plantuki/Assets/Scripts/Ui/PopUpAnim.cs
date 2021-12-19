using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  DG.Tweening;

[RequireComponent(typeof(RectTransform))]
public class PopUpAnim : MonoBehaviour {
    private RectTransform _rectTransform;
    private Vector2 originalSize;
    
    [SerializeField] private float tweenTime;
    private void Awake() {
        _rectTransform = GetComponent<RectTransform>();
        originalSize = _rectTransform.localScale;
    }

    private void OnEnable() {
        _rectTransform.localScale = Vector3.zero;
        _rectTransform.DOScale(originalSize, tweenTime).SetEase(Ease.OutElastic, 1, 0f);
    }
}
