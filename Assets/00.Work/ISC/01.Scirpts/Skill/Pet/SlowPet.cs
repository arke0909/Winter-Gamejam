using UnityEngine;

public class SlowPet : Pet
{
    [SerializeField] private float _slowPower;
    protected override void AfterInit()
    {
        _slowPower = UpgradeArray[UpgradeArrIdx];
    }

    protected override void Attack(GameObject target)
    {
        Vector2 dir = target.transform.position - fireForceTrm.position;
        dir.Normalize();
        float rotate = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        fireForceTrm.rotation = Quaternion.Euler(0, 0, rotate);
        SlowPetBullet obj = poolManagerSO.Pop(poolTypeSO) as SlowPetBullet;
        obj.Initialize(fireForceTrm.position, dir, Damage, KnockbackPower);
        obj.AfaterInit(_slowPower);
    }
    
    public override void Upgrade()
    {
        base.Upgrade();
        
        _slowPower = UpgradeArray[UpgradeArrIdx];
    }
}
