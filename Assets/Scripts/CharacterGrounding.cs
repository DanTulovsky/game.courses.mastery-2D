using System.Collections.Generic;
using UnityEngine;

public class CharacterGrounding : MonoBehaviour
{
    [SerializeField] private List<Transform> positions;
    [SerializeField] private float maxDistance = 0.25f;
    [SerializeField] private LayerMask layerMask;

    public bool IsGrounded { get; private set; }

    private Rigidbody2D _rigidbody2D;
    private Transform _groundedObject;
    private Vector3? _groundedObjectLastPosition;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // if (!IsGrounded)
        IsGrounded = CheckIsGrounded();

        Debug.Log(IsGrounded);

        // StickToMovingObjects();
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

        foreach (Transform pos in positions)
        {
            RaycastHit2D hit = Physics2D.Raycast(pos.position, Vector2.down, maxDistance, layerMask);
            Debug.DrawRay(pos.position, Vector3.down * maxDistance, Color.red);

            // hit.distance check handles the case when jumping through a platform
            if (hit.collider != null && hit.distance > 0)
            {
                if (_groundedObject != hit.collider.transform)
                {
                    _groundedObject = hit.collider.transform;
                    _groundedObjectLastPosition = _groundedObject.position;
                }
                return true;
            }
        }

        _groundedObject = null;
        return false;
    }
}