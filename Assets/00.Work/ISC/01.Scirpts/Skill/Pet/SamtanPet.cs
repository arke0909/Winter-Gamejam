using GGMPool;
using Unity.Mathematics;
using UnityEngine;

public class SamtanPet : Pet
{
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
        _dir.Normalize();
        _rotates[0] = Mathf.Atan2(_dir.y, _dir.x) * Mathf.Rad2Deg;
        _rotates[1] = _rotates[0] + 20;
        _rotates[2] = _rotates[0] - 20;
        
        for (int i = 0; i < _maxBullet; i++)
        {
            Quaternion q = Quaternion.Euler(0f, 0f, _rotates[i]);
            fireForceTrm.localRotation = q;
            SamtanPetBullet obj = poolManagerSO.Pop(poolTypeSO) as SamtanPetBullet;
            float flip = _dir.x > fireForceTrm.position.x ? -1 : 1;
            obj.transform.localScale = new Vector3(flip, 1, 1);
            obj.transform.rotation = flip == 1 ? Quaternion.Euler(0,0,fireForceTrm.localRotation.eulerAngles.z - 180) : Quaternion.Euler(0,0,fireForceTrm.localRotation.eulerAngles.z);
            obj.Initialize(fireForceTrm.position, fireForceTrm.right, Damage, KnockbackPower);
        }
    }

    public override void Upgrade()
    {
        base.Upgrade();
        
        AttackTime = UpgradeArray[UpgradeArrIdx];
    }
}
