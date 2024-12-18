using UnityEngine;

[CreateAssetMenu(menuName = "SO/PetSO")]
public class PetSO : ScriptableObject
{
    [Header("Main Settings")]
    public float Damage;
    public float LifeTime;
    public float Speed;
    
    [Space(10)]
    [Header("Attack Settings")]
    public float AttackTime;
    public float AttackRange;
    public float KnockbackPower;

    [Space(10)] [Header("Level Settings")]
    public float[] IncreaseValues;

}
