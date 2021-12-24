using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

public class UICoin : MonoBehaviour
{
    private TweenerCore<Quaternion, Vector3, QuaternionOptions> rotateTween;
    
    private void Start()
    {
        DOTween.Init();
        GameManager.Instance.OnCoinsChanged += Animate;
    }

    private void Animate(int coins)
    {
        TweenerCore<Quaternion, Vector3, QuaternionOptions> rotateTween;
        transform.DORotate(new Vector3(0, 180, 0), 1f, RotateMode.LocalAxisAdd);
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnCoinsChanged -= Animate;
        rotateTween.Kill();
    }
}