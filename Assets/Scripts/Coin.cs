
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private Animator _animator;
    private AudioSource _audioSource;
    private static readonly int SpinTrigger = Animator.StringToHash("Spin");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        _animator.speed = 3;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        _animator.SetTrigger(SpinTrigger);
        _audioSource.Play();

        GameManager.Instance.AddCoin();
        StartCoroutine(Vanish());
    }

    private IEnumerator Vanish()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}