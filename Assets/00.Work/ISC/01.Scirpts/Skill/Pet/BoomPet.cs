using Unity.Mathematics;
using UnityEditor;
using UnityEngine;

public class BoomPet : Pet
{
    protected override void AfterInit()
    {
        Damage = UpgradeArray[UpgradeArrIdx];
    }

    protected override void Attack(GameObject target)
    {
        Vector2 dir = target.transform.position - fireForceTrm.position;
        
        float rotate = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        
        fireForceTrm.localRotation = Quaternion.Euler(0, 0, rotate);
        BoomPetBullet obj = poolManagerSO.Pop(poolTypeSO) as BoomPetBullet;
        float flip = dir.x > fireForceTrm.position.x ? -1 : 1;
        obj.transform.localScale = new Vector3(flip, 1, 1);
        obj.Initialize(fireForceTrm.position, dir, Damage, KnockbackPower);
    }
    
    public override void Upgrade()
    {
        base.Upgrade();
        
        Damage = UpgradeArray[UpgradeArrIdx];
    }
}