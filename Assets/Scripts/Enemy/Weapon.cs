using System;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public event Action ObjectEntered;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Player>())
            ObjectEntered?.Invoke();
    }
}