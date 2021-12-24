using UnityEngine;

public class BreakableBox : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (!col.HitByPlayer()) return;
        if (!col.HitFromBellow()) return;
        
        Destroy(gameObject);

    }
}