using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.LowLevel;

public class CharacterGrounding : MonoBehaviour
{
    [SerializeField] private Transform leftFoot;
    [SerializeField] private Transform rightFoot;
    [SerializeField] private float maxDistance = 0.25f;
    [SerializeField] private LayerMask layerMask;

    public bool IsGrounded { get; private set; }
    private readonly List<Transform> _feet = new();

    private void Awake()
    {
        _feet.Add(leftFoot);
        _feet.Add(rightFoot);
    }

    private void Update()
    {
        IsGrounded = CheckIsGrounded();
    }

    private bool CheckIsGrounded()
    {
        foreach (Transform foot in _feet)
        {
            RaycastHit2D hit = Physics2D.Raycast(foot.position, Vector2.down, maxDistance, layerMask);
            Debug.DrawRay(foot.position, Vector3.down * maxDistance, Color.red);

            if (hit)
            {
                return true;
            }
        }

        return false;
    }
}