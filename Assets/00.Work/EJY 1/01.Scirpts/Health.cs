using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [field : SerializeField]
    public float MaxHealth { get; private set; }
    private float _currentHealth;
    private Rigidbody2D _rigidCompo;

    public UnityEvent DieEvent;
    public UnityEvent HitEvent;

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

    public virtual void TakeDamage(float damage/*, Vector2 normal, Vector2 point, float knockbackPower*/)
    {
        _currentHealth -= damage;
        HitEvent?.Invoke();

        //if (knockbackPower > 0)
            //GetKnockback(normal * -1, knockbackPower);

        if (_currentHealth == 0)
            DieEvent?.Invoke();

    }

    /*public void GetKnockback(Vector3 direction, float power)
    {
        Vector3 difference = direction * power;
        rbCompo.AddForce(difference, ForceMode2D.Impulse);

        if (_kbCoroutine != null)
            StopCoroutine(_kbCoroutine);

        _kbCoroutine = StartCoroutine(KnockbackCoroutine());
    }

    private IEnumerator KnockbackCoroutine()
    {
        _canMove = false;
        yield return new WaitForSeconds(0.2f);
        _rigidCompo.linearVelocity = Vector2.zero;
        _canMove = true;
    }*/

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
