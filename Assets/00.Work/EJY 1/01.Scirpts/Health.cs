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
    private EnemyBrain _enemyBrain;

    public UnityEvent DieEvent;
    public UnityEvent HitEvent;

    private Coroutine _kbCoroutine;

    private void Awake()
    {
        _rigidCompo = GetComponent<Rigidbody2D>();
        _enemyBrain = GetComponent<EnemyBrain>();

    }

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
        _rigidCompo = GetComponent<Rigidbody2D>();
    }

    public virtual void TakeDamage(float damage, Vector2 normal, Vector2 point, float knockbackPower = 0)
    {
        _currentHealth -= damage;
        HitEvent?.Invoke();

        if (knockbackPower > 0)
            GetKnockback(normal * -1, knockbackPower);

        if (_currentHealth == 0)
            DieEvent?.Invoke();

    }

    public void GetKnockback(Vector3 direction, float power)
    {
        Vector3 difference = direction * power;
        _rigidCompo.AddForce(difference, ForceMode2D.Impulse);

        if (_kbCoroutine != null)
            StopCoroutine(_kbCoroutine);

        _kbCoroutine = StartCoroutine(KnockbackCoroutine());
    }

    private IEnumerator KnockbackCoroutine()
    {
        _enemyBrain._CanMove = false;
        yield return new WaitForSeconds(0.2f);
        _rigidCompo.linearVelocity = Vector2.zero;
        _enemyBrain._CanMove = true;
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
