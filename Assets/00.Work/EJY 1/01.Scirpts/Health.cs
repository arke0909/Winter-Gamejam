using UnityEngine;

public abstract class Health : MonoBehaviour
{
    public float maxHealth = 100f; 
    public float currentHealth;

    protected virtual void Start()
    {
        currentHealth = maxHealth;
    }
    

   //������
    public virtual void TakeDamage(float damage)
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
       //��θ� �����̽��ϴ�
    }

    // ü���� ȸ��
    public virtual void Heal(float healAmount)
    {
        currentHealth = Mathf.Min(currentHealth + healAmount, maxHealth);
    }
}