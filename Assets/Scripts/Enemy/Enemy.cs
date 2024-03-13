using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Patrol _patrol;

    private void Start()
        => _patrol = GetComponent<Patrol>();

    private void Update()
        => _patrol.Move();
}