using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Spike : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private Trap _trap;

    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _trap.TrapActivated += Move;
    }

    private void OnDisable()
    {
        _trap.TrapActivated -= Move;
    }

    private void Move()
    {
        _rigidbody.bodyType = RigidbodyType2D.Dynamic;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out Health health))
        {
            health.TakeDamage(_damage);
        }

        Destroy(gameObject);
    }
}