using System.Collections.Generic;
using UnityEngine;

public class CharacterGrounding : MonoBehaviour
{
    [SerializeField] private Transform leftFoot;
    [SerializeField] private Transform rightFoot;
    [SerializeField] private float maxDistance = 0.25f;
    [SerializeField] private LayerMask layerMask;

    public bool IsGrounded { get; private set; }

    private readonly List<Transform> _feet = new();
    private Transform _groundedObject;
    private Vector3? _groundedObjectLastPosition;

    private void Awake()
    {
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
        if (_groundedObject != null)
        {
            if (_groundedObjectLastPosition.HasValue && _groundedObjectLastPosition.Value != _groundedObject.position)
            {
                Vector2 delta = _groundedObject.position - _groundedObjectLastPosition.Value;
                GetComponent<Rigidbody2D>().position += delta; 
                // transform.position += delta;
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