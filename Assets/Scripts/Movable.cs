using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Core.PathCore;
using DG.Tweening.Plugins.Options;
using UnityEngine;

public class Movable : MonoBehaviour
{
    [SerializeField] private Transform start;
    [SerializeField] private Transform end;
    [SerializeField] private float speed = 2f;

    private Rigidbody2D _rigidbody2D;
    private Vector2[] _wayPoints;
    private TweenerCore<Vector3, Path, PathOptions> moveTween;

    private void Awake()
    {
        _wayPoints = new Vector2[] { start.position, end.position };
    }

    private void Start()
    {
        DOTween.Init();

        _rigidbody2D = GetComponentInChildren<Rigidbody2D>();

        float pathDuration = (end.position.x - start.position.x) / speed;

        moveTween = _rigidbody2D
            .DOPath(_wayPoints, pathDuration, PathType.Linear, PathMode.Sidescroller2D, 10, Color.red)
            .SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
    }

    private void OnDestroy()
    {
        moveTween.Kill();
    }
}