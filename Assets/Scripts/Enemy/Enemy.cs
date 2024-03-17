using UnityEngine;

[RequireComponent(typeof(MoverEnemy), typeof(Attack))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private DetectionArea _detectionArea;
    [SerializeField] private Weapon _weapon;

    private MoverEnemy _mover;
    private Attack _attack;

    private void OnEnable()
    {
        _detectionArea.ObjectEntered += MoveFollow;
        _detectionArea.ObjectExited += MovePatrol;
        _weapon.ObjectEntered += Attack;
    }

    private void Start()
    {
        _mover = GetComponent<MoverEnemy>();
        _attack = GetComponent<Attack>();

        MovePatrol();
    }

    private void Update()
    {
        _mover.Move();
    }

    private void OnDisable()
    {
        _detectionArea.ObjectEntered -= MoveFollow;
        _detectionArea.ObjectExited -= MovePatrol;
        _weapon.ObjectEntered -= Attack;
    }

    private void MovePatrol()
       => _mover.ChangeState(MovementState.Patrol);

    private void MoveFollow()
        => _mover.ChangeState(MovementState.Follow);

    private void Attack()
    {       
        _mover.ChangeState(MovementState.Attack);
        _attack.StartAction();
    }
}