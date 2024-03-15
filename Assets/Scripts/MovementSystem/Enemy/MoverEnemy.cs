using UnityEngine;

[RequireComponent(typeof(Patrol), typeof(Follow))]
public class MoverEnemy : MonoBehaviour
{
    private MovementState _currentState;
    private Patrol _patrol;
    private Follow _pursuit;

    private void Start()
    {
        _patrol = GetComponent<Patrol>(); 
        _pursuit = GetComponent<Follow>();
    }

    public void Move()
    {
        switch (_currentState)
        {
            case MovementState.Patrol:
                _patrol.Move();
                break;

            case MovementState.Follow:
                _pursuit.Move();
                break;
        }
    }

    public void ChangeState(MovementState state)
        => _currentState = state;
}