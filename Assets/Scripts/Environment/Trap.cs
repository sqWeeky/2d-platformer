using System;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public event Action TrapActivated;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.TryGetComponent(out Player palyer))
        {
            TrapActivated?.Invoke();
        }            
    }
}