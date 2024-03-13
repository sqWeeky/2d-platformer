using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Patrol _patrol;

    private void Start()
    {
        _patrol = GetComponent<Patrol>();
        _patrol.Move();
    }    
}