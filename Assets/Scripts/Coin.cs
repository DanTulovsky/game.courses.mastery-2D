
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private Animator _animator;
    private static readonly int SpinTrigger = Animator.StringToHash("Spin");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _animator.speed = 2;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        _animator.SetTrigger(SpinTrigger);

        GameManager.Instance.AddCoin();
        StartCoroutine(Vanish());
    }

    private IEnumerator Vanish()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}