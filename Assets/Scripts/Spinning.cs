using DG.Tweening;
using UnityEngine;

public class Spinning : MonoBehaviour
{
    [SerializeField] private float speed = 60f;
    
    private void Start()
    {
        float duration = 360 / speed;
        
        transform
            .DOLocalRotate(new Vector3(0, 0, -360), duration, RotateMode.LocalAxisAdd)
            .SetEase(Ease.Linear).SetLoops(-1);
    }
}