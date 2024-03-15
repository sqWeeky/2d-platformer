using UnityEngine;

public class MedicalKit : MonoBehaviour
{
    [SerializeField] private int _extraHealth;

    private HealthSystem _healthSystem;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Player>())
        {
            _healthSystem = other.gameObject.GetComponent<HealthSystem>();
            _healthSystem.SetHealth(_extraHealth);
            Destroy(gameObject);
        }
    }
}