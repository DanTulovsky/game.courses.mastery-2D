using System.Security.Cryptography;
using UnityEngine;

public class ShellFlipped : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    private Collider2D _collider2D;
    private Rigidbody2D _rigidbody2D;

    private Vector2 _direction;

    private void Awake()
    {
        _collider2D = GetComponent<Collider2D>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.HitByPlayer())
            HandlePlayerCollision(col);
        else
        {
            if (col.HitFromSide())
            {
                LaunchShell(col);
                
                ITakeShellHits takeShellHits = col.collider.GetComponent<ITakeShellHits>();
                takeShellHits?.HandleShellHit(this);
            }
        }
    }

    private void HandlePlayerCollision(Collision2D col)
    {
        var playerMovementController = col.collider.GetComponent<PlayerMovementController>();

        if (_direction.magnitude == 0)
        {
            LaunchShell(col);
            if (col.HitFromTop())
                playerMovementController.Bounce();
        }
        else
        {
            if (col.HitFromTop())
            {
                _direction = Vector2.zero;
                playerMovementController.Bounce();
            }
            else
            {
                GameManager.Instance.KillPlayer();
            }
        }
    }

    private void FixedUpdate()
    {
        _rigidbody2D.velocity = new Vector2(_direction.x * speed, _rigidbody2D.velocity.y);
    }

    private void LaunchShell(Collision2D col)
    {
        if (col.HitFromLeft())
            _direction = Vector2.right;
        if (col.HitFromRight())
            _direction = Vector2.left;
    }
}