using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "SO/Enemy/EnemySO")]
public class EnemyDataSO : ScriptableObject
{
    public float hp; //ü��
    public float damage; //������
    public float attackSpeed; //���ݼӵ�
    public float range; //�����Ÿ�
    public float moveSpeed; //�̵��ӵ�
}
