
using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class UICoin : MonoBehaviour
{
    private void Start()
    {
        DOTween.Init();
        
        GameManager.Instance.OnCoinsChanged += Animate;
    }

    private void Animate(int coins)
    {
        Debug.Log("animating");
        transform.DORotate(new Vector3(0, 180, 0), 1f, RotateMode.LocalAxisAdd);
    }
}