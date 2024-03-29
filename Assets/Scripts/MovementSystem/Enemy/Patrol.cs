using UnityEngine;

public class Patrol : MonoBehaviour, IMovable
{
    [SerializeField] private float _currentSpeed;
    [SerializeField] private Transform[] _moveSpots;

    private int _spot = 0;
    private float _minDistanse = 0.2f;

    public void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, _moveSpots[_spot].position, _currentSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, _moveSpots[_spot].position) < _minDistanse)
            _spot = ++_spot % _moveSpots.Length;
    }

    public Transform GetSpot()
         => _moveSpots[_spot];

}