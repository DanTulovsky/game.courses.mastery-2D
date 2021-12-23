using UnityEngine;
using UnityEngine.SceneManagement;

public class KillOnTouch : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        PlayerMovementController player = col.collider.GetComponent<PlayerMovementController>();
        if (!player) return;

        GameManager.Instance.KillPlayer();
    }
}