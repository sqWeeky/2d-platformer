using UnityEngine;

public class Follow : MonoBehaviour, IMovable
{
    [SerializeField] private float _currentSpeed;
    [SerializeField] private Transform _target;   

    private Quaternion _directionRight = Quaternion.Euler(0, 0, 0);
    private Quaternion _directionLeft = Quaternion.Euler(0, 180, 0);

    public void Move()
    {
        Flip();

        transform.position = Vector2.MoveTowards(transform.position, _target.position, _currentSpeed * Time.deltaTime);
    }    

    private void Flip()
    {
        if (transform.position.x < _target.position.x)
            transform.localRotation = _directionRight;
        else
            transform.localRotation = _directionLeft;
    }
}