using UnityEngine;

[RequireComponent(typeof(Health))]
public class Picker : MonoBehaviour
{
    private int _extraHealth;
    private Health _healthSystem;
    public bool IsTake { get; private set; }

    private void Start()
    {
        IsTake = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Coin coin))
            Destroy(other.gameObject);

        if (other.TryGetComponent(out MedicalKit medicalKit))
        {
            _extraHealth = medicalKit.ExtraHealth;
            _healthSystem = GetComponent<Health>();
            _healthSystem.Heal(_extraHealth);
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out Knife knife))
        {
            IsTake = true;
            Destroy(knife);
        }
    }
}