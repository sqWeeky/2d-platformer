using UnityEngine;

public class MovementSystemForPlayer : MonoBehaviour, IMovable
{
    [SerializeField] private float _currentSpeed;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private float _jumpHeight;
    [SerializeField] private Animator _animator;

    private Rigidbody2D _rigidbody;
    private bool _isGrounded;
    private MovementState _currentState = MovementState.Idle;

    public void Move()
    {
        switch (_currentState)
        {
            case MovementState.Idle:
                _animator.SetTrigger("Idle");
                _animator.SetBool("Run", false);
                _animator.ResetTrigger("Jump");
                break;

            case MovementState.Run:
                Run();
                _animator.ResetTrigger("Idle");
                _animator.SetBool("Run", true);
                _animator.ResetTrigger("Jump");
                break;

            case MovementState.Jumping:
                Jumping();
                _animator.SetTrigger("Jump");
                _animator.SetBool("Run", false);
                _animator.ResetTrigger("Idle");
                break;
        }
    }

    private void Start()
       => _rigidbody = GetComponent<Rigidbody2D>();

    public void ChangeState(MovementState state)
        => _currentState = state;

    private void Run()
    {
        Flip();
        MoveOfHorizontal(_currentSpeed);
    }

    private void Jumping()
    {
        CheckGround();

        if (_isGrounded)
            _rigidbody.AddForce(transform.up * _jumpHeight, ForceMode2D.Force);
    }

    private void MoveOfHorizontal(float speed)
        => _rigidbody.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, _rigidbody.velocity.y);

    private void Flip()
    {
        if (Input.GetAxis("Horizontal") > 0)
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        if (Input.GetAxis("Horizontal") < 0)
            transform.localRotation = Quaternion.Euler(0, 180, 0);
    }

    private void CheckGround()
    {
        Debug.DrawRay(transform.position, Vector2.down);
        RaycastHit2D raycast = Physics2D.Raycast(transform.position, Vector2.down, 1f, _layerMask);

        if (raycast.collider != null)
            _isGrounded = true;
        else
            _isGrounded = false;
    }
}