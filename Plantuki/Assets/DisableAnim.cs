using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class DisableAnim : MonoBehaviour
{
    private RectTransform _rectTransform;
    
    [SerializeField] private float tweenTime;
    private void Awake() {
        _rectTransform = GetComponent<RectTransform>();
    }

    public void DisableMenu() {
        _rectTransform.DOScale(Vector3.zero, tweenTime).SetEase(Ease.InElastic, 1, 0.4f)
            .OnComplete(() => gameObject.SetActive(false));
    }

    
}
