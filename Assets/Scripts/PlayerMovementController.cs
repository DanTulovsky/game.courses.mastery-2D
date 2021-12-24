using UnityEngine;

[RequireComponent(typeof(CharacterGrounding))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovementController : MonoBehaviour, IMove
{
    [SerializeField] private float moveSpeed = 5;
    [SerializeField] private float jumpForce = 400;
    [SerializeField] private float wallJumpForce = 300;
    [SerializeField] private float bounceForce = 600;

    private Rigidbody2D _rigidbody2D;
    private CharacterGrounding _characterGrounding;
    private float _horizontal;

    public float Speed => _horizontal;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
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
        UpdateHorizontal();

        if (Mathf.Abs(_horizontal) > 0)
        {
            Vector3 movement = new Vector3(_horizontal, 0);
            transform.position += movement * (Time.deltaTime * moveSpeed);
        }
    }

    private void UpdateHorizontal()
    {
        _horizontal = Input.GetAxis("Horizontal");
    }

    private void Jump()
    {
        if (_characterGrounding != null && _characterGrounding.IsGrounded)
        {
            _rigidbody2D.AddForce(Vector2.up * jumpForce);

            if (_characterGrounding.GroundedDirection != Vector2.down)
            {
                _rigidbody2D.AddForce(_characterGrounding.GroundedDirection * (-1f * wallJumpForce));
            }
        }
    }

    public void Bounce()
    {
        _rigidbody2D.AddForce(Vector2.up * bounceForce);
    }
}