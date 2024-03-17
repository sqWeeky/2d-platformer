using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Patrol), typeof(Follow))]
public class MoverEnemy : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private MovementState _currentState;
    private Patrol _patrol;
    private Follow _pursuit;
    private Transform _target;
    private Quaternion _directionRight = Quaternion.Euler(0, 0, 0);
    private Quaternion _directionLeft = Quaternion.Euler(0, 180, 0);
    private Dictionary<MovementState, string> _states;

    private void Start()
    {
        _states = new()
        {
            [MovementState.Walk] = "Walk",
            [MovementState.Attack] = "Attack",
        };
        _patrol = GetComponent<Patrol>();
        _pursuit = GetComponent<Follow>();
    }

    public void Move()
    {
        switch (_currentState)
        {
            case MovementState.Patrol:
                _animator.SetTrigger(_states[MovementState.Walk]);
                _animator.ResetTrigger(_states[MovementState.Attack]);
                _target = _patrol.GetSpot();
                Flip();
                _patrol.Move();
                break;

            case MovementState.Follow:
                _animator.SetTrigger(_states[MovementState.Walk]);
                _animator.ResetTrigger(_states[MovementState.Attack]);
                _target = _pursuit.GetTarget();
                Flip();
                _pursuit.Move();
                break;

            case MovementState.Attack:
                _animator.ResetTrigger(_states[MovementState.Walk]);
                _animator.SetTrigger(_states[MovementState.Attack]);
                break;
        }
    }

    public void ChangeState(MovementState state)
        => _currentState = state;

    private void Flip()
    {
        if (transform.position.x < _target.position.x)
            transform.localRotation = _directionRight;
        else
            transform.localRotation = _directionLeft;
    }
}