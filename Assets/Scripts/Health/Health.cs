using UnityEngine;
using System;

public class Health : MonoBehaviour
{
    [SerializeField] private float _currentHealth;
    [SerializeField] private float _maxHealth;
    [SerializeField] private Transition _transition;

    private int _minHealth = 0;
    private Dead _dead;
    public event Action<float> HealthChanged;

    public float MaxHealth => _maxHealth;
    public float CurrentHealth => _currentHealth;

    private void Awake()
    {
        _dead = GetComponent<Dead>();

        if (PlayerPrefs.HasKey("health") && gameObject.TryGetComponent(out Player player))
            _currentHealth = PlayerPrefs.GetFloat("health");
    }

    private void OnEnable()
    {
        _transition.LevelComplete += SelfHealth;
    }

    private void OnDisable()
    {
        _transition.LevelComplete -= SelfHealth;
    }

    public void TakeDamage(float damage)
    {
        if (damage > 0)
            _currentHealth -= damage;

        _currentHealth = DetermineValue(_currentHealth);
        HealthChanged?.Invoke(_currentHealth);

        if (_currentHealth <= 0)
        {
            if (gameObject.TryGetComponent(out Player player))
                _dead.Activation();
            else
                Destroy(gameObject);
        }

    }

    public void Heal(float extraHealth)
    {
        if (extraHealth > 0)
            _currentHealth += extraHealth;

        _currentHealth = DetermineValue(_currentHealth);
        HealthChanged?.Invoke(_currentHealth);
    }

    private float DetermineValue(float currentValue)
        => Mathf.Clamp(currentValue, _minHealth, _maxHealth);

    private void SelfHealth()
    {
        PlayerPrefs.SetFloat("health", _currentHealth);
    }
}