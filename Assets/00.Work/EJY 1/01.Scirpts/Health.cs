using System;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [field : SerializeField]
    public float MaxHealth { get; private set; }
    private float _currentHealth;

    public UnityEvent DieEvent;

    public float CurrentHealth
    {
        get
        {
            return _currentHealth;
        }

        private set
        {
            if(value <= 0)
                _currentHealth = 0;
            else
                _currentHealth = value;
        }
    }

    public void Initialize(float maxHealth)
    {
        MaxHealth = maxHealth; 
        CurrentHealth = maxHealth;
    }

    public virtual void TakeDamage(float damage)
    {
        CurrentHealth -= damage;
        if (_currentHealth == 0)
            Die();
    }

    protected virtual void Die()
    {
        DieEvent?.Invoke();
    }

    public float GetCurrentHealth()
    {
        return _currentHealth;
    }

    internal void UpgradeHealth(float value)
    {
        MaxHealth += value;
        _currentHealth = MaxHealth;
    }
}
