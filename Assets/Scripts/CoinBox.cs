using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBox : MonoBehaviour
{
    [SerializeField] private Sprite disabledSprite;
    [SerializeField] private int totalCoins = 1;

    private SpriteRenderer _spriteRenderer;
    private AudioSource _audioSource;
    private Sprite _enabledSprite;

    private int _remainingCoins;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _audioSource = GetComponent<AudioSource>();
        _enabledSprite = _spriteRenderer.sprite;
        _remainingCoins = totalCoins;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (_remainingCoins <= 0) return;

        if (!HitFromBellow(col)) return;
        if (!HitByPlayer(col)) return;

        PlayAudio();
        
        GameManager.Instance.AddCoin();
        _remainingCoins--;

        if (_remainingCoins <= 0)
        {
            _spriteRenderer.sprite = disabledSprite;
        }
    }

    private void PlayAudio()
    {
        if (_audioSource != null) _audioSource.Play();
    }

    private static bool HitByPlayer(Collision2D col)
    {
        return col.collider.GetComponent<PlayerMovementController>();
    }

    private static bool HitFromBellow(Collision2D col)
    {
        return col != null && col.GetContact(0).normal.y > 0;
    }
}