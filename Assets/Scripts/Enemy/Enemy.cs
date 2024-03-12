using UnityEngine;

public class Enemy : MonoBehaviour
{
    private MovementSystemForEnemy _movementSystem;

    private void Start()
    {
        _movementSystem = GetComponent<MovementSystemForEnemy>();        
    }

    private void Update()
    {
        _movementSystem.ChangeState(MovementState.Patrol);
        _movementSystem.Move();       
    }
}