using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MoverPlayer : MonoBehaviour, IMovable
{
    [SerializeField] private float _currentSpeed;
    [SerializeField] private LayerMask _ground;
    [SerializeField] private float _jumpHeight;
    [SerializeField] private Animator _animator;

    private Rigidbody2D _rigidbody;
    private bool _isGrounded;
    private MovementState _currentState = MovementState.Idle;
    private string[] _states = { "Idle", "Run", "Jump" };
    private string _direction = "Horizontal";
    private float _distanseRaycast = 1.0f;
    private Quaternion _directionRight = Quaternion.Euler(0, 0, 0);
    private Quaternion _directionLeft = Quaternion.Euler(0, 180, 0);

    public void Move()
    {
        switch (_currentState)
        {
            case MovementState.Idle:
                _animator.SetTrigger(_states[0]);
                _animator.SetBool(_states[1], false);
                _animator.ResetTrigger(_states[2]);
                break;

            case MovementState.Run:
                Run();
                _animator.ResetTrigger(_states[0]);
                _animator.SetBool(_states[1], true);
                _animator.ResetTrigger(_states[2]);
                break;

            case MovementState.Jumping:
                Jumping();
                _animator.ResetTrigger(_states[0]);
                _animator.SetBool(_states[1], false);
                _animator.SetTrigger(_states[2]);
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

        _rigidbody.velocity = new Vector2(Input.GetAxis(_direction) * _currentSpeed, _rigidbody.velocity.y);
    }

    private void Jumping()
    {
        CheckGround();

        if (_isGrounded)
            _rigidbody.AddForce(transform.up * _jumpHeight, ForceMode2D.Force);
    }   

    private void Flip()
    {
        if (Input.GetAxis(_direction) > 0)
            transform.localRotation = _directionRight;

        if (Input.GetAxis(_direction) < 0)
            transform.localRotation = _directionLeft;
    }

    private void CheckGround()
    {
        RaycastHit2D raycast = Physics2D.Raycast(transform.position, Vector2.down, _distanseRaycast, _ground);

        if (raycast.collider != null)
            _isGrounded = true;
        else
            _isGrounded = false;
    }
}