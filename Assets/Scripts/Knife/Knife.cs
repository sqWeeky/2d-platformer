using System.Collections;
using UnityEngine;

public class Knife : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private int _damage;

    private float _timeDeath = 15f;
    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        StartCoroutine(Death());
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector2(_speed, _rigidbody.velocity.y);
    }

    private IEnumerator Death()
    {
        yield return new WaitForSeconds(_timeDeath);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out Health healthChanger))
        {
            healthChanger.TakeDamage(_damage);
            Destroy(gameObject);
        }

        if (other.gameObject.layer == 6)
        {
            _rigidbody.velocity = new Vector2(0, 0);
            _speed = 0;
        }
    }
}