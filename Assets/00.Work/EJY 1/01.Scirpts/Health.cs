using System;
using UnityEngine;

public abstract class Health : MonoBehaviour
{
    public float currentHealth;  
    protected float maxHealth;   

   
    public void Initialize(float maxHealth)
    {
        this.maxHealth = maxHealth; 
        currentHealth = maxHealth;  
    }

    // - 
    public virtual void TakeDamage(float damage, Vector2 normal)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // ��� 
    protected virtual void Die()
    {
       
    }

    //+
    public virtual void Heal(float healAmount)
    {
        currentHealth = Mathf.Min(currentHealth + healAmount, maxHealth);
    }
    //��ȯ
    public float GetCurrentHealth()
    {
        return currentHealth;
    }

    internal void TakeDamage(int damage, Vector2 normal, Vector2 point, float knockbackPower)
    {
        throw new NotImplementedException();
    }
}
