using GGMPool;
using Unity.Mathematics;
using UnityEngine;

public class SamtanPet : Pet
{
    [SerializeField] private PoolManagerSO poolManagerSO;
    [SerializeField] private PoolTypeSO poolTypeSO;
    [SerializeField] private Transform fireForceTrm;
    
    private Vector3 _dir;

    private int _maxBullet = 3;

    private float[] _rotates;
    
    protected override void AfterInit()
    {
        AttackTime = UpgradeArray[UpgradeArrIdx];
    }
    
    protected override void Attack(GameObject target)
    {
        _rotates = new float[_maxBullet];
        
        _dir = target.transform.position - fireForceTrm.position;
        _rotates[0] = Mathf.Atan2(_dir.y, _dir.x) * Mathf.Rad2Deg;
        _rotates[1] = _rotates[0] + 20;
        _rotates[2] = _rotates[0] - 20;
        
        for (int i = 0; i < _maxBullet; i++)
        {
            Quaternion q = Quaternion.Euler(0f, 0f, _rotates[i]);
            fireForceTrm.localRotation = q;
            PetBullet obj = poolManagerSO.Pop(poolTypeSO) as PetBullet;
            obj.SetDir(fireForceTrm.position, fireForceTrm.right);
        }
    }

    public override void Upgrade()
    {
        base.Upgrade();
        
        AttackTime = UpgradeArray[UpgradeArrIdx];
    }
}