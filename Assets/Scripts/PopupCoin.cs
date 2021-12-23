using System.Collections;
using UnityEngine;

public class PopupCoin : MonoBehaviour
{
    private Animator _animator;

    private const float LifeTime = 1f;
    private const float Speed = 4;
    private static readonly int SpinTrigger = Animator.StringToHash("Spin");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        if (_animator != null)
        {
            _animator.SetTrigger(SpinTrigger);
        }
        StartCoroutine(Die());
    }

    private IEnumerator Die()
    {
        yield return new WaitForSeconds(LifeTime);
        Destroy(gameObject);
    }

    private void Update()
    {
        var direction = Vector3.up;
        transform.position += direction * (Speed * Time.deltaTime);
    }
}