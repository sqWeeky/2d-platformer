using UnityEngine;

[RequireComponent(typeof(MoverEnemy))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private DetectionArea _detectionArea;

    private MoverEnemy _mover;

    private void OnEnable()
    {
        _detectionArea.ObjectEntered += MoveFollow;
        _detectionArea.ObjectExited += MovePatrol;
    }

    private void Start()
    {
        _mover = GetComponent<MoverEnemy>();

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
    }

    private void MovePatrol()
       => _mover.ChangeState(MovementState.Patrol);

    private void MoveFollow()
        => _mover.ChangeState(MovementState.Follow);
}