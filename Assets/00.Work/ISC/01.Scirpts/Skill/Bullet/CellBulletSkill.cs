using GGMPool;
using UnityEngine;

public class CellBulletSkill : Skill, IBulletAble
{
    [SerializeField] private PoolManagerSO poolManagerSo;
    [SerializeField] private PoolTypeSO poolTypeSo;

    [SerializeField] private int[] upgradeValues;
    private float _angle;
    private float _plusAngle;
    private Gun _gun; 
    
    protected override void AfterInit()
    {
        _gun = Player.GetCompo<Gun>();

        int cnt = upgradeValues[UpgradeArrIdx];

        _plusAngle = 360 / (float)cnt;
        _angle = _plusAngle;
    }


    public void BulletAbility(Transform targetTrm)
    {
        for (int i = 0; i < upgradeValues[UpgradeArrIdx]; i++)
        {
            PlayerBullet obj = poolManagerSo.Pop(poolTypeSo) as PlayerBullet;
            targetTrm.rotation = Quaternion.Euler(0, 0, _angle);
            obj.Initialize(targetTrm.position, targetTrm.right, _gun.CurrentAttack / 2, 0);
            _angle += _plusAngle;
        }
    }
}
