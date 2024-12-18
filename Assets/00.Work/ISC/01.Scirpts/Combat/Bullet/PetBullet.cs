using UnityEngine;

public class PetBullet : Bullet
{
    [SerializeField] private PetSO _petSo;
    
    public override void ResetItem()
    {
        base.ResetItem();
        speed = _petSo.Speed;
        LifeTime = _petSo.LifeTime;
    }
}
