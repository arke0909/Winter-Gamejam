using UnityEngine;

public class EnemyHealth : Health
{
    public float NextHealth { get; set; } = 1;

    public float GetNextHealth()
    {
        return  MaxHealth - NextHealth;
    }

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
    }
}
