
using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class CoinAudio : MonoBehaviour
{
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        GameManager.Instance.OnCoinsChanged += Play;
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnCoinsChanged -= Play;
    }

    private void Play(int coins)
    {
        _audioSource.Play();
    }
}