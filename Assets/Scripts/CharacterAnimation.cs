using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    private Animator _animator;
    private CharacterGrounding _characterGrounding;
    private IMove _movable;

    private static readonly int WalkingProperty = Animator.StringToHash("Walking");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _characterGrounding = GetComponent<CharacterGrounding>();
        _movable = GetComponent<IMove>();
    }

    private void Update()
    {
        bool isWalking = _movable.Speed > 0 && _characterGrounding.IsGrounded;
        if (_animator != null) _animator.SetBool(WalkingProperty, isWalking);
    }
}