using UnityEngine;

public class Player : MonoBehaviour
{
    private MoverPlayer _movementSystem;
    private string _axisHorizontal = "Horizontal";
    private float _userInput;

    private void Start()
       => _movementSystem = GetComponent<MoverPlayer>();

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            _movementSystem.ChangeState(MovementState.Jumping);
            _movementSystem.Move(_userInput);
            return;
        }

        if (Input.GetAxis(_axisHorizontal) != 0)
        {
            _movementSystem.ChangeState(MovementState.Run);
            _movementSystem.Move(_userInput);
            return;
        }

        _movementSystem.ChangeState(MovementState.Idle);
        _movementSystem.Move(_userInput);
    }

    private void Update()
    {
        _userInput = Input.GetAxis(_axisHorizontal);
    }
}