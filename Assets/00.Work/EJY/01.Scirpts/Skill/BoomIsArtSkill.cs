    using GGMPool;
using System;
using UnityEngine;

[Serializable]
struct BoomSkillValue
{
    public float damageRadius;
    public float multiply;
}

public class BoomIsArtSkill : Skill, IBulletAble
{
    [SerializeField] private PoolManagerSO _poolManager;
    [SerializeField] private PoolTypeSO _poolType;

    [SerializeField] private BoomSkillValue[] _values = new BoomSkillValue[5];
    [SerializeField] private ContactFilter2D filter;

    [SerializeField] private float knockbackPower;

    private Collider2D[] _colliders;

    public bool IsHas { get; set; } = false;
    
    private Gun _gun;
    protected override void AfterInit()
    {
        _gun = Player.GetCompo<Gun>();
        _colliders = new Collider2D[1000];
    }

    protected override void Upgrade()
    {
    }

    public void BulletAbility(Transform target)
    {
        if (IsHas == false) IsHas = true;
        int cnt = Physics2D.OverlapCircle(transform.position, _values[UpgradeArrIdx].damageRadius, filter, _colliders);
        
        Debug.Log("Boom Ability");
        EffectPlayer effect = _poolManager.Pop(_poolType) as EffectPlayer;
        effect.transform.localScale = new Vector2(_values[UpgradeArrIdx].damageRadius, _values[UpgradeArrIdx].damageRadius);
        effect.SetPositionAndPlay(target.position);
        for (int i = 0; i < cnt; i++)
        {
            if (_colliders[i].TryGetComponent(out Health health))
            {
                Vector2 direction = _colliders[i].transform.position - transform.position;

                RaycastHit2D hit = Physics2D.Raycast(transform.position, direction.normalized, direction.magnitude, filter.layerMask);

                Debug.Log(_gun);
                health.TakeDamage(_gun.CurrentAttack * _values[UpgradeArrIdx].multiply, hit.normal, hit.point, knockbackPower);
            }
        }
    }

}
