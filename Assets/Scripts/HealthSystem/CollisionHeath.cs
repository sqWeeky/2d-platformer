using UnityEngine;

public class CollisionHealth : MonoBehaviour
{
    [SerializeField] private int _extraHealth;
    [SerializeField] private string _tag;

    private HealthSystem _healthSystem;

    private void OnCollisionEnter2D(Collision2D other)
    {
        //_healthSystem = other.gameObject.GetComponent<HealthSystem>();

        if (other.gameObject.tag == _tag)
        {
            _healthSystem = other.gameObject.GetComponent<HealthSystem>();
            _healthSystem.SetHealth(_extraHealth);
            Destroy(gameObject);
        }
    }
}