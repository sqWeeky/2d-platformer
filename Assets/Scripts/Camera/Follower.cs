using UnityEngine;

public class Follower : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private Vector3 _offcet;
    [SerializeField] private float _smoothing = 1f;

    private Vector3 _nexPosition;

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        _nexPosition = Vector3.Lerp(transform.position, _playerTransform.position + _offcet, _smoothing * Time.fixedDeltaTime);
        transform.position = _nexPosition;
    }
}