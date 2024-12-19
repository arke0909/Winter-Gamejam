using UnityEngine;

public interface IBulletAble
{
    public void BulletAbility(Transform targetTrm);
    
    public bool IsHas { get; set; }
}
