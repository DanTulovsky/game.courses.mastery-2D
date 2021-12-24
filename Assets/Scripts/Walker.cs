using System;
using UnityEngine;

public class Walker : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private GameObject spawnOnStompPrefab;

    private Rigidbody2D _rigidbody2D;
    private Collider2D _collider2D;
    private SpriteRenderer _spriteRenderer;

    private Vector2 _direction = Vector3.left;
    private float _epsilon = 0.1f;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _collider2D = GetComponent<Collider2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        _rigidbody2D.MovePosition(_rigidbody2D.position + _direction * (speed * Time.fixedDeltaTime));
    }

    private void LateUpdate()
    {
        if (ReachedEdge() || CollidedWith())
        {
            SwitchDirections();
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.HitByPlayer())
        {
            if (col.HitFromTop())
                HandleWalkerStomp();
            else
                GameManager.Instance.KillPlayer();
        }
    }

    private void HandleWalkerStomp()
    {
        if (spawnOnStompPrefab != null)
            Instantiate(spawnOnStompPrefab, transform.position, transform.rotation);

        Destroy(gameObject);
    }

    private bool CollidedWith()
    {
        // TODO: This doesn't handle bumping into something small (something not touched by the ray)
        float x = GetForwardX();
        float y = _collider2D.bounds.max.y;

        Vector2 origin = new(x, y);
        Debug.DrawRay(origin, _direction * _epsilon);

        RaycastHit2D hit = Physics2D.Raycast(origin, _direction, _epsilon);
        if (!hit.collider) return false;
        if (hit.collider.isTrigger) return false;
        if (hit.collider.HitByPlayer()) return false;

        return true;
    }

    private bool ReachedEdge()
    {
        float x = GetForwardX();
        float y = _collider2D.bounds.min.y;

        Vector2 origin = new Vector2(x, y);
        Debug.DrawRay(origin, Vector2.down * _epsilon);

        var hit = Physics2D.Raycast(origin, Vector2.down, _epsilon);
        return !hit.collider;
    }

    private float GetForwardX()
    {
        float x = Math.Abs(_direction.x - (-1)) < float.Epsilon
            ? _collider2D.bounds.min.x - _epsilon
            : _collider2D.bounds.max.x + _epsilon;
        float y = _collider2D.bounds.max.y;
        return x;
    }

    private void SwitchDirections()
    {
        _direction *= -1;
        _spriteRenderer.flipX = !_spriteRenderer.flipX;
    }
}