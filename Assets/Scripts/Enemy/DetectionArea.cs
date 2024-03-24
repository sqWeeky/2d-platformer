using System;
using UnityEngine;

public class DetectionArea : MonoBehaviour
{
    public event Action ObjectEntered;
    public event Action ObjectExited;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
            ObjectEntered?.Invoke();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
            ObjectExited?.Invoke();
    }
}