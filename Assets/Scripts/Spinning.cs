using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

public class Spinning : MonoBehaviour
{
    [SerializeField] private float speed = 60f;

    private TweenerCore<Quaternion, Vector3, QuaternionOptions> spinTween;

    private void Start()
    {
        DOTween.Init();

        float duration = 360 / speed;

        spinTween = transform
            .DOLocalRotate(new Vector3(0, 0, -360), duration, RotateMode.LocalAxisAdd)
            .SetEase(Ease.Linear).SetLoops(-1);
    }

    private void OnDestroy()
    {
        spinTween.Kill();
    }
}