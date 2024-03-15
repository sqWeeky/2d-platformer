using UnityEngine;

public class Patrol : MonoBehaviour, IMovable
{
    [SerializeField] private float _currentSpeed;
    [SerializeField] private Transform[] _moveSpots;

    private int _spot = 0;
    private float _minDistanse = 0.2f;
    private Quaternion _directionRight = Quaternion.Euler(0, 0, 0);
    private Quaternion _directionLeft = Quaternion.Euler(0, 180, 0);

    public void Move()
    {
        Flip();
        transform.position = Vector2.MoveTowards(transform.position, _moveSpots[_spot].position, _currentSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, _moveSpots[_spot].position) < _minDistanse)        
            _spot = ++_spot % _moveSpots.Length; 
    }

    private void Flip()
    {
        if (transform.position.x < _moveSpots[_spot].position.x)        
            transform.localRotation = _directionRight;        
        else        
            transform.localRotation = _directionLeft;        
    }
}