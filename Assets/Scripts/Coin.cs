using UnityEngine;

public class Coin : MonoBehaviour
{
    private Animator _animator;
    private static readonly int SpinTrigger = Animator.StringToHash("Spin");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _animator.speed = 10;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.HitByPlayer()) return;
        
        _animator.SetTrigger(SpinTrigger);

        GameManager.Instance.AddCoin();
    }

    // Vanish is called as an event from the Animation Controller.
    private void Vanish()
    {
        Destroy(gameObject);
    }
}