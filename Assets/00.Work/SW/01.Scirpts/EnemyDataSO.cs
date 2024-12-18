using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "SO/Enemy/EnemySO")]
public class EnemyDataSO : ScriptableObject
{
    public float hp; //체력
    public float damage; //데미지
    public float attackSpeed; //공격속도
    public float range; //사정거리
    public float moveSpeed; //이동속도
}
