using System;
using UnityEngine;

public class LimeBulletSkill : Skill, IBulletAble
{
    [SerializeField] private LayerMask whatIsEnemy;
    [SerializeField] private float[] upgradeValues;
    [SerializeField] private float range;
    
    private float _slowPower;
    
    private float _slowStartTime = 0;
    private float _slowDuration;

    private bool _isSlowing = false;

    private EnemyStat _stat;

    private Transform _targetTrm;
    
    private Collider2D _collider;

    public bool IsHas { get; set; } = false;

    protected override void AfterInit()
    {
        _slowDuration = upgradeValues[UpgradeArrIdx];
    }

    private void Update()
    {
        if (Time.time - _slowStartTime > _slowDuration && _isSlowing)
        {
            if (_stat == null) return;
            _isSlowing = false;
            _stat.SetSpeed(1);
        }
    }

    protected override void Upgrade()
    {
        _slowDuration = upgradeValues[UpgradeArrIdx];
    }

    public void BulletAbility(Transform targetTrm)
    {
        if (IsHas == false) IsHas = true;
        _targetTrm = targetTrm;
        _collider = Physics2D.OverlapCircle(_targetTrm.position, range, whatIsEnemy);
        if (_collider != null)
        {
            if (_collider.gameObject.TryGetComponent(out EnemyStat stat))
            {
                if (_isSlowing)
                {
                    _slowStartTime = Time.time;
                    return;
                }
                _slowStartTime = Time.time;
                _stat = stat;
                _stat.SetSpeed(_slowPower);
                _isSlowing = true;
            }
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        if (_targetTrm == null) return;
        Gizmos.DrawWireSphere(_targetTrm.position, range);
        Gizmos.color = Color.white;
    }
}
