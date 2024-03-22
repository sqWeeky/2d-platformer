using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float _parallax;

    private float _startPositionX;

    private void Start()
    {
        _startPositionX = transform.position.x;
    }

    private void Update()
    {
        float distanceX = (_camera.transform.position.x * (1 - _parallax));
        transform.position = new Vector3(_startPositionX + distanceX, transform.position.y, transform.position.z);
    }
}