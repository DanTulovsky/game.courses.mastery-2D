using UnityEngine;

[RequireComponent(typeof(CharacterGrounding))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5;
    [SerializeField] private float jumpForce = 400;

    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private CharacterGrounding _characterGrounding;

    private static readonly int WalkingProperty = Animator.StringToHash("Walking");

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _characterGrounding = GetComponent<CharacterGrounding>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");

        if (Mathf.Abs(horizontal) > 0)
        {
            if (_animator != null) _animator.SetBool(WalkingProperty, true);
            Vector3 movement = new Vector3(horizontal, 0);

            transform.position += movement * (Time.deltaTime * moveSpeed);
        }
        else
        {
            _animator.SetBool(WalkingProperty, false);
        }
    }

    private void Jump()
    {
        if (_characterGrounding != null && _characterGrounding.IsGrounded)
        {
            _rigidbody2D.AddForce(Vector2.up * jumpForce);
        }
    }
}
