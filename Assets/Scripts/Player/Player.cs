using UnityEngine;

[RequireComponent(typeof(MoverPlayer))]
public class Player : MonoBehaviour
{
    private MoverPlayer _mover;
    private string _axisHorizontal = "Horizontal";
    private float _userInput;
    private int _numberKnives;
    private int _maxKnives = 5;
    private Take _take;

    private void Start()
    {
        _numberKnives = _maxKnives;
        _mover = GetComponent<MoverPlayer>();
        _take = GetComponent<Take>();
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            _mover.ChangeState(MovementState.Jump);
            _mover.Move(_userInput);
            return;
        }

        if (Input.GetAxis(_axisHorizontal) != 0)
        {
            _mover.ChangeState(MovementState.Run);
            _mover.Move(_userInput);
            return;
        }

        _mover.ChangeState(MovementState.Idle);
        _mover.Move(_userInput);
    }

    private void Update()
    {
        _userInput = Input.GetAxis(_axisHorizontal);

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _mover.ChangeState(MovementState.Attack);
            _mover.Move(_userInput);
            return;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (_numberKnives != 0)
            {
                _numberKnives--;
                _mover.ChangeState(MovementState.ThrowKnife);
                _mover.Move(_userInput);
                return;
            }
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (_take.IsTake == true)
            {
                Debug.Log(_numberKnives);
                _numberKnives++;
                Debug.Log(_numberKnives);
            }
        }
    }
}