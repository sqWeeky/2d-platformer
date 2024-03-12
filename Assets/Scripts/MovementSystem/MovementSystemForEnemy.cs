using UnityEngine;

public class MovementSystemForEnemy : MonoBehaviour, IMovable
{
    [SerializeField] private float _currentSpeed;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private Transform _groundDetection;
    [SerializeField] private Animator _animator;

    private bool _isGrounded;
    private bool _movingRight = true;
    private Vector3 _vectorRight = new(0, 180, 0);
    private Vector3 _vectorLeft = new(0, 0, 0);
    private MovementState _currentState = MovementState.Idle;

    public void Move()
    {
        switch (_currentState)
        {
            case MovementState.Patrol:
                Patrol();
                break;
        }
    }

    public void ChangeState(MovementState state)
        => _currentState = state;

    private void Patrol()
    {
        CheckGround();
        Flip();
        MoveOfHorizontal(_currentSpeed);
    }

    private void MoveOfHorizontal(float speed)
        => transform.Translate(Vector2.right * speed * Time.deltaTime);

    private void Flip()
    {
        if (_isGrounded == false)
        {
            if (_movingRight)
            {
                transform.eulerAngles = _vectorRight;
                _movingRight = false;
            }
            else
            {
                transform.eulerAngles = _vectorLeft;
                _movingRight = true;
            }
        }
    }

    private void CheckGround()
    {
        Debug.DrawRay(_groundDetection.transform.position, Vector2.down);
        RaycastHit2D raycast = Physics2D.Raycast(_groundDetection.transform.position, Vector2.down, 0.2f, _layerMask);

        if (raycast.collider != null)
            _isGrounded = true;
        else
            _isGrounded = false;
    }
}