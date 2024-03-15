using UnityEngine;

[RequireComponent(typeof(HealthSystem))]
public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private int _damage;

    private HealthSystem _healthSystem;

    private void OnCollisionEnter2D(Collision2D other)
    { 
        if (other.gameObject.GetComponent<Enemy>())
        {
            _healthSystem = other.gameObject.GetComponent<HealthSystem>();
            _healthSystem.TakeDamage(_damage);
        }
    }
}