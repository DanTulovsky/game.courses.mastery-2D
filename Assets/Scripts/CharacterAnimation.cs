using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
public class CharacterAnimation : MonoBehaviour
{
    private Animator _animator;
    private CharacterGrounding _characterGrounding;
    private IMove _movable;
    private SpriteRenderer _spriteRenderer;

    private static readonly int WalkingProperty = Animator.StringToHash("Walking");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _characterGrounding = GetComponent<CharacterGrounding>();
        _movable = GetComponent<IMove>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (_movable.Speed != 0)
            _spriteRenderer.flipX = _movable.Speed > 0;

        bool isWalking = Mathf.Abs(_movable.Speed) > 0 && _characterGrounding.IsGrounded;
        if (_animator != null) _animator.SetBool(WalkingProperty, isWalking);
    }
}