using System;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [field : SerializeField]
    public float MaxHealth { get; private set; }
    private float _currentHealth;
    private Rigidbody2D _rigidCompo;

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

    public virtual void TakeDamage(float damage/*, float knockPower*/)
    {
        CurrentHealth -= damage;
        if (_currentHealth == 0)
            Die();
    }

    /*public void TakeDamage(int amount, Vector2 normal, Vector2 point, float knockbackPower)
    {
        _currentHealth -= amount;
        OnHitEvent?.Invoke();
        //normal과 point, 넉백 등은 차후에 여기서 사용합니다.

        if (knockbackPower > 0)
            _owner.MovementCompo.GetKnockback(normal * -1, knockbackPower);

        if (_currentHealth <= 0)
        {
            OnDeadEvent?.Invoke();
        }
    }*/

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
