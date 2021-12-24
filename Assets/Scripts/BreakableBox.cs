using UnityEngine;

public class BreakableBox : MonoBehaviour, ITakeShellHits
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (!col.HitByPlayer()) return;
        if (!col.HitFromBellow()) return;
        
        DestroyBox();
    }

    public void HandleShellHit(ShellFlipped shellFlipped)
    {
        DestroyBox();
    }

    private void DestroyBox()
    {
        Destroy(gameObject);
    }
}