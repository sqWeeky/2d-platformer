using UnityEngine;

public class CoinPicker : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (TryGetComponent(out Player player))
            Destroy(other.gameObject);
    }
}