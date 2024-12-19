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
    //[SerializeField] private 

    [SerializeField] private BoomSkillValue[] _values = new BoomSkillValue[5];
    [SerializeField] private ContactFilter2D filter;

    [SerializeField] private float knockbackPower;

    private Collider2D[] _colliders;

    public bool IsHas { get; set; } = false;
    
    private Gun _gun;
    protected override void AfterInit()
    {
        _gun = Player.GetComponent<Gun>();
    }

    public void BulletAbility(Transform target)
    {
        if (IsHas == false) IsHas = true;
        int cnt = Physics2D.OverlapCircle(transform.position, _values[UpgradeArrIdx].damageRadius, filter, _colliders);

        for (int i = 0; i < cnt; i++)
        {
            if (_colliders[i].TryGetComponent(out Health health))
            {
                Vector2 direction = _colliders[i].transform.position - transform.position;

                RaycastHit2D hit = Physics2D.Raycast(transform.position, direction.normalized, direction.magnitude, filter.layerMask);

                health.TakeDamage(_gun.CurrentAttack * _values[UpgradeArrIdx].multiply, hit.normal, hit.point, knockbackPower);
            }
        }
    }

}
