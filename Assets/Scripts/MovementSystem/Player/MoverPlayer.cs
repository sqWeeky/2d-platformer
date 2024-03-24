using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Attack), typeof(Shot))]
public class MoverPlayer : MonoBehaviour, IMovable
{
    [SerializeField] private float _currentSpeed;
    [SerializeField] private LayerMask _ground;
    [SerializeField] private float _jumpHeight;
    [SerializeField] private Animator _animator;

    private Rigidbody2D _rigidbody;
    private bool _isGrounded;
    private MovementState _currentState = MovementState.Idle;
    private string _axisHorizontal = "Horizontal";
    private float _distanseRaycast = 1.0f;
    private Quaternion _directionRight = Quaternion.Euler(0, 0, 0);
    private Quaternion _directionLeft = Quaternion.Euler(0, 180, 0);
    private Dictionary<MovementState, string> _states;
    private Attack _attack;
    private Shot _shotKnife;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _attack = GetComponent<Attack>();
        _shotKnife = GetComponent<Shot>();
        _states = new()
        {
            [MovementState.Idle] = "Idle",
            [MovementState.Run] = "Run",
            [MovementState.Jump] = "Jump",
            [MovementState.Attack] = "Attack",
            [MovementState.ShotKnife] = "ShotKnife",
        };
    }

    public void Move(float userInput)
    {
        switch (_currentState)
        {
            case MovementState.Idle:
                Idle();
                _animator.SetTrigger(_states[MovementState.Idle]);
                _animator.SetBool(_states[MovementState.Run], false);
                _animator.ResetTrigger(_states[MovementState.Jump]);
                _animator.ResetTrigger(_states[MovementState.Attack]);
                break;

            case MovementState.Run:
                Run(userInput);
                _animator.ResetTrigger(_states[MovementState.Idle]);
                _animator.SetBool(_states[MovementState.Run], true);
                _animator.ResetTrigger(_states[MovementState.Jump]);
                _animator.ResetTrigger(_states[MovementState.Attack]);
                break;

            case MovementState.Jump:
                Jumping();
                _animator.ResetTrigger(_states[MovementState.Idle]);
                _animator.SetBool(_states[MovementState.Run], false);
                _animator.SetTrigger(_states[MovementState.Jump]);
                _animator.ResetTrigger(_states[MovementState.Attack]);
                break;

            case MovementState.Attack:
                _attack.StartAction();
                _animator.ResetTrigger(_states[MovementState.Idle]);
                _animator.SetBool(_states[MovementState.Run], false);
                _animator.ResetTrigger(_states[MovementState.Jump]);
                _animator.SetTrigger(_states[MovementState.Attack]);
                break;

            case MovementState.ShotKnife:
                _shotKnife.Activation();
                _animator.ResetTrigger(_states[MovementState.Idle]);
                _animator.SetBool(_states[MovementState.Run], false);
                _animator.ResetTrigger(_states[MovementState.Jump]);
                _animator.ResetTrigger(_states[MovementState.Attack]);
                break;
        }
    }

    public void ChangeState(MovementState state)
        => _currentState = state;

    private void Idle()
        => _rigidbody.velocity = new Vector2(0, _rigidbody.velocity.y);

    private void Run(float userInput)
    {
        Flip();

        _rigidbody.velocity = new Vector2(userInput * _currentSpeed, _rigidbody.velocity.y);
    }

    private void Jumping()
    {
        CheckGround();

        if (_isGrounded)
            _rigidbody.AddForce(transform.up * _jumpHeight, ForceMode2D.Force);
    }

    private void Flip()
    {
        if (Input.GetAxis(_axisHorizontal) > 0)
            transform.localRotation = _directionRight;

        if (Input.GetAxis(_axisHorizontal) < 0)
            transform.localRotation = _directionLeft;
    }

    private void CheckGround()
    {
        RaycastHit2D raycast = Physics2D.Raycast(transform.position, Vector2.down, _distanseRaycast, _ground);
        _isGrounded = raycast.collider != null;
    }
}