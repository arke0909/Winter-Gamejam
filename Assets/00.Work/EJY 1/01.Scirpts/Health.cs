using UnityEngine;

public abstract class Health : MonoBehaviour
{
    public float maxHealth = 100f; 
    public float currentHealth;

    protected virtual void Start()
    {
        currentHealth = maxHealth;
    }
    

   //µ¥¹ÌÁö
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
       //¶ì·Î¸® Á×À¸¼Ì½À´Ï´Ù
    }

    // Ã¼·ÂÀ» È¸º¹
    public virtual void Heal(float healAmount)
    {
        currentHealth = Mathf.Min(currentHealth + healAmount, maxHealth);
    }
}