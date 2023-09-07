using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEditor.UIElements;

public class SelfDestroy : MonoBehaviour
{
    public float FadeInDuration = 1f;
    public float RemainDuration = 0f;
    public float FadeOutDuration = 1f;

    void OnEnable()
    {
        RawImage rawImage = GetComponent<RawImage>();
        rawImage.color = new Color(1, 1, 1, 0);
        rawImage.DOKill();
        rawImage.DOFade(1, FadeInDuration).OnComplete(() =>
        {
            rawImage.DOFade(0, FadeOutDuration).SetDelay(RemainDuration).OnComplete(() =>
            {
                gameObject.SetActive(false);
            });
        });
    }

    void Update()
    {

    }
}