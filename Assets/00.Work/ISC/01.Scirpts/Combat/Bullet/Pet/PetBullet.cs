using UnityEngine;

public class PetBullet : Bullet
{
    [SerializeField] private PetSO _petSo;

    protected override void Hit()
    {
        Debug.Log("펫이 쏴씀");
        PetHit();
    }

    protected virtual void PetHit()
    {
        
    }

    public override void ResetItem()
    {
        base.ResetItem();
        speed = _petSo.Speed;
        LifeTime = _petSo.LifeTime;
    }   
}
    