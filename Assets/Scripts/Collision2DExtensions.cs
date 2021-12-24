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
    
    public static bool HitFromLeft(this Collision2D col)
    {
        return col != null && col.GetContact(0).normal.x > 0;
    }
    
    public static bool HitFromRight(this Collision2D col)
    {
        return col != null && col.GetContact(0).normal.x < 0;
    }
}