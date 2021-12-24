using UnityEngine;

public class CompleteLevelFlag : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        GameManager.Instance.MoveToNextLevel();
    }
}