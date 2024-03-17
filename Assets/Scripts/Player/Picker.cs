using UnityEngine;

[RequireComponent(typeof(HealthChanger))]
public class Picker : MonoBehaviour
{
    private int _extraHealth;
    private HealthChanger _healthSystem;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Coin coin))
            Destroy(other.gameObject);

        if (other.TryGetComponent(out MedicalKit medicalKit))
        {
            _extraHealth = medicalKit.ExtraHealth;
            _healthSystem = GetComponent<HealthChanger>();
            _healthSystem.Heal(_extraHealth);
            Destroy(other.gameObject);
        }
    }
}