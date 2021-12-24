using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    // TODO: set should be private
    public bool Passed { get;  set; }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        PlayerMovementController player = col.GetComponent<PlayerMovementController>();
        if (!player) return;

        Passed = true;
    }

}