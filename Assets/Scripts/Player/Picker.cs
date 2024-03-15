using UnityEditor;
using UnityEngine;

public class Picker : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Coin coin))
            Destroy(other.gameObject);       
    }
}