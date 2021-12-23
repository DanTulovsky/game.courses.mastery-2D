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
        _animator.speed = 10;
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        _animator.SetTrigger(SpinTrigger);
        _audioSource.Play();

        GameManager.Instance.AddCoin();
        // StartCoroutine(Vanish());
    }

    // Vanish is called as an event from the Animation Controller.
    private void Vanish()
    {
        // // Wait for animation to end
        // yield return new WaitForSeconds(_animator.GetCurrentAnimatorStateInfo(0).length +
        //                                 _animator.GetCurrentAnimatorStateInfo(0).normalizedTime);
        Destroy(gameObject);
    }
}