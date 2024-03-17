using UnityEngine;

[RequireComponent(typeof(HealthSystem))]
public class Picker : MonoBehaviour
{
    private int _extraHealth;
    private HealthSystem _healthSystem;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Coin coin))
            Destroy(other.gameObject);

        if (other.TryGetComponent(out MedicalKit medicalKit))
        {
            _extraHealth = medicalKit.GetHealth();
            _healthSystem = GetComponent<HealthSystem>();
            _healthSystem.SetHealth(_extraHealth);
            Destroy(other.gameObject);
        }
    }
}