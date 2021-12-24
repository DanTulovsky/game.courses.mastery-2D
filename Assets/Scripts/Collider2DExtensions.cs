using UnityEngine;

public static class Collider2DExtensions
{
    public static bool HitByPlayer(this Collider2D col)
    {
        return col.GetComponent<PlayerMovementController>();
    }
}