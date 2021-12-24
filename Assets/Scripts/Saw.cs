using System;
using DG.Tweening;
using UnityEngine;

public class Saw : MonoBehaviour
{
    [SerializeField] private Transform start;
    [SerializeField] private Transform end;
    [SerializeField] private float pathDuration = 6f;
    [SerializeField] private Sprite sawSprite;

    private Vector3[] _wayPoints;

    private void Awake()
    {
        _wayPoints = new Vector3[] { start.position, end.position };
    }

    private void Start()
    {
        Sequence sawSequence = DOTween.Sequence().SetLoops(-1, LoopType.Yoyo);

        var move = transform.DOPath(_wayPoints, pathDuration, PathType.Linear, PathMode.Sidescroller2D, 10, Color.red)
            .SetEase(Ease.Linear);
        var rotate = transform.DOLocalRotate(new Vector3(0, 0, -360), pathDuration, RotateMode.LocalAxisAdd)
            .SetEase(Ease.Linear);

        sawSequence.Insert(0, move);
        sawSequence.Insert(0, rotate);
    }

    private void Update()
    {
    }
}