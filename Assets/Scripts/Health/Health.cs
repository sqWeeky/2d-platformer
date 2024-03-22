using UnityEngine;
using System;

public class Health : MonoBehaviour
{
    [SerializeField] private float _currentHealth;
    [SerializeField] private float _maxHealth;

    private int _minHealth = 0;
    public event Action<float> HealthChanged;

    public float MaxHealth => _maxHealth;
    public float CurrentHealth => _currentHealth;

    public void TakeDamage(int damage)
    {
        if (damage > 0)
            _currentHealth -= damage;

        _currentHealth = DetermineValue(_currentHealth);
        HealthChanged?.Invoke(_currentHealth);

        if (_currentHealth <= 0)
            Destroy(gameObject);
    }

    public void Heal(int extraHealth)
    {
        if (extraHealth > 0)
            _currentHealth += extraHealth;

        _currentHealth = DetermineValue(_currentHealth);
        HealthChanged?.Invoke(_currentHealth);
    }

    private float DetermineValue(float currentValue)
        => Mathf.Clamp(currentValue, _minHealth, _maxHealth);
}