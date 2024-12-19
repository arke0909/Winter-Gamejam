using UnityEngine;

public class EnemyHealth : Health
{
    public float NextHealth { get; set; } = 10;

    public float GetNextHealth()
    {
        return  MaxHealth - NextHealth;
    }

}
