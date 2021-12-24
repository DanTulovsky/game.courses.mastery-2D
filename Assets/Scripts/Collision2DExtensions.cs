using UnityEngine;

public static class Collision2DExtensions
{
    public static bool HitByPlayer(this Collision2D col)
    {
        return col.collider.GetComponent<PlayerMovementController>();
    }

    public static bool HitFromBellow(this Collision2D col)
    {
        return col != null && col.GetContact(0).normal.y > 0.5;
    }
    
    public static bool HitFromTop(this Collision2D col)
    {
        return col != null && col.GetContact(0).normal.y < -0.5;
    }
}