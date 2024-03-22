using UnityEngine;

public class Thorns : MonoBehaviour
{
    [SerializeField] private int _damage = 15;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out Health healthChanger))
            healthChanger.TakeDamage(_damage);
    }
}