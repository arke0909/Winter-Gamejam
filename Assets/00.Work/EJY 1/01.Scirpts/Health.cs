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
    public virtual void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // »ç¸Á 
    protected virtual void Die()
    {
       
    }

    //+
    public virtual void Heal(float healAmount)
    {
        currentHealth = Mathf.Min(currentHealth + healAmount, maxHealth);
    }
}
