using UnityEngine;

public class Follow : MonoBehaviour, IMovable
{
    [SerializeField] private float _currentSpeed;
    [SerializeField] private Transform _target;

    public void Move()
        => transform.position = Vector2.MoveTowards(transform.position, _target.position, _currentSpeed * Time.deltaTime);

    public Transform GetTarget()
    {
        return _target;
    }
}