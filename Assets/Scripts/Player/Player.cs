using UnityEngine;

public class Player : MonoBehaviour
{
    private MoverPlayer _movementSystem;

    private void Start()
       => _movementSystem = GetComponent<MoverPlayer>();

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            _movementSystem.ChangeState(MovementState.Jumping);
            _movementSystem.Move();
            return;
        }

        if (Input.GetAxis("Horizontal") != 0)
        {
            _movementSystem.ChangeState(MovementState.Run);
            _movementSystem.Move();
            return;
        }

        _movementSystem.ChangeState(MovementState.Idle);
        _movementSystem.Move();
    }
}