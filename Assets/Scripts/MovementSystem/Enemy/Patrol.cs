using System.Collections;
using UnityEngine;

public class Patrol : MonoBehaviour, IMovable
{
    [SerializeField] private float _currentSpeed;
    [SerializeField] private Transform[] _moveSpots;

    private int _spot = 0;
    private int _nextSpot;
    private float _minDistanse = 0.2f;

    public void Move()
       => StartCoroutine(StartMovement());

    private IEnumerator StartMovement()
    {
        Flip();

        while (Vector3.Distance(transform.position, _moveSpots[_spot].position) > _minDistanse)
        {
            transform.position = Vector3.MoveTowards(transform.position, _moveSpots[_spot].position, _currentSpeed * Time.deltaTime);
            yield return null;
        }

        _nextSpot = _spot + 1;
        _spot = _nextSpot % _moveSpots.Length;

        yield return null;
        StartCoroutine(StartMovement());
    }

    private void Flip()
    {
        if (_spot != _moveSpots.Length - 1)
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        else
            transform.localRotation = Quaternion.Euler(0, 180, 0);
    }
}