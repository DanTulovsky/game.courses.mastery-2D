using System.Collections.Generic;
using UnityEngine;

public class CharacterGrounding : MonoBehaviour
{
    [SerializeField] private Transform leftFoot;
    [SerializeField] private Transform rightFoot;
    [SerializeField] private float maxDistance = 0.25f;
    [SerializeField] private LayerMask layerMask;

    public bool IsGrounded { get; private set; }

    private Rigidbody2D _rigidbody2D;
    private readonly List<Transform> _feet = new();
    private Transform _groundedObject;
    private Vector3? _groundedObjectLastPosition;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _feet.Add(leftFoot);
        _feet.Add(rightFoot);
    }

    private void Update()
    {
        if (!IsGrounded)
            IsGrounded = CheckIsGrounded();
        
        StickToMovingObjects();
    }

    private void StickToMovingObjects()
    {
        
        // Note that RigidBody2D physics is still in effect. When platform stops, that will affect the player.
        if (_groundedObject != null)
        {
            if (_groundedObjectLastPosition.HasValue && _groundedObjectLastPosition.Value != _groundedObject.position)
            {
                Vector2 delta = _groundedObject.position - _groundedObjectLastPosition.Value;
                _rigidbody2D.position += delta; 
            }

            _groundedObjectLastPosition = _groundedObject.position;
        }
        else
        {
            _groundedObjectLastPosition = null;
            return;
        }
    }

    private bool CheckIsGrounded()
    {
        foreach (Transform foot in _feet)
        {
            RaycastHit2D hit = Physics2D.Raycast(foot.position, Vector2.down, maxDistance, layerMask);
            Debug.DrawRay(foot.position, Vector3.down * maxDistance, Color.red);

            // hit.distance check handles the case when jumping through a platform
            if (hit && hit.distance > 0)
            {
                _groundedObject = hit.collider.transform;
                return true;
            }
        }

        _groundedObject = null;
        return false;
    }
}