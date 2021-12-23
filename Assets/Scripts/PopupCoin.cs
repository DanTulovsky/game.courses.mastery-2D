using System;
using System.Collections;
using UnityEngine;

public class PopupCoin : MonoBehaviour
{
    private Animator _animator;
    
    private float _lifeTime = 1f;
    private float _speed = 4;
    private static readonly int SpinTrigger = Animator.StringToHash("Spin");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        if (_animator != null)
        {
            Debug.Log("animating");
            _animator.SetTrigger(SpinTrigger);
        }
        StartCoroutine(Die());
    }

    private IEnumerator Die()
    {
        yield return new WaitForSeconds(_lifeTime);
        Destroy(gameObject);
    }

    private void Update()
    {
        var direction = Vector3.up;
        transform.position += direction * (_speed * Time.deltaTime);
    }
}