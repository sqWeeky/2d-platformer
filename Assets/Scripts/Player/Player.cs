using UnityEngine;

[RequireComponent(typeof(MoverPlayer))]
public class Player : MonoBehaviour
{
    [SerializeField] private LifeSteal _lifeSteal;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _clipAttack;

    private MoverPlayer _mover;
    private string _axisHorizontal = "Horizontal";
    private float _userInput;

    private void Start()
    {
        _mover = GetComponent<MoverPlayer>();
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
            _audioSource.PlayOneShot(_clipAttack);
            return;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            _mover.ChangeState(MovementState.ShotKnife);
            _mover.Move(_userInput);
            _audioSource.PlayOneShot(_clipAttack);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            _lifeSteal.Activation();
            return;
        }
    }
}