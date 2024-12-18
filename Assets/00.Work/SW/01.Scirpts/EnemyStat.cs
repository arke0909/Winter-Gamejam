using UnityEngine;

public class EnemyStat : MonoBehaviour
{
    public float Hp { get;private set; } //ü��
    public float Damage { get; private set; } //������
    public float AttackSpeed { get; private set; } //���ݼӵ�
    public float Range { get; private set; }//�����Ÿ�
    public float MoveSpeed { get; private set; } //�̵��ӵ�

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
