using UnityEngine;

public class EnemyStat : MonoBehaviour
{
    public float Hp { get;private set; } //체력
    public float Damage { get; private set; } //데미지
    public float AttackSpeed { get; private set; } //공격속도
    public float Range { get; private set; }//사정거리
    public float MoveSpeed { get; private set; } //이동속도

    public void SetStat(EnemyDataSO dataSO)
    {
        Hp = dataSO.hp;
        Damage = dataSO.damage;
        AttackSpeed = dataSO.attackSpeed;
        Range = dataSO.range;
        MoveSpeed = dataSO.moveSpeed;
    }

    public void UpgradeStat(float value)
    {
        Hp *= value;
        Damage *= value;
    }
}
