using UnityEngine;

public class HealthChanger : MonoBehaviour
{
    [SerializeField] private int _currentHealth;
    [SerializeField] private int _maxHealth;

    public void TakeDamage(int damage)
    {
        if (damage > 0)
            _currentHealth -= damage;

        if (_currentHealth <= 0)
            Destroy(gameObject);
    }

    public void Heal(int extraHealth)
    {
        if (extraHealth > 0)
            _currentHealth += extraHealth;

        if (_currentHealth >= _maxHealth)
            _currentHealth = _maxHealth;
    }
}
