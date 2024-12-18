using UnityEngine;

[CreateAssetMenu(menuName = "SO/PetSO")]
public class PetSO : ScriptableObject
{
    [Header("Main Settings")]
    public float Damage;
    
    [Space(10)]
    [Header("Attack Settings")]
    public float AttackTime;
    public float AttackRange;

}
