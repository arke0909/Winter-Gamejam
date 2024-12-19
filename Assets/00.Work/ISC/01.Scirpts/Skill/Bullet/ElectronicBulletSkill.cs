using System;
using UnityEngine;

public class ElectronicBulletSkill : Skill, IBulletAble
{
    [SerializeField] private float _chainRange;
    private int _chainCnt = 3;
    [SerializeField] private int[] upgradeValues;
    [SerializeField] private ContactFilter2D fliter;
    Collider2D[] _colliders;
    
    private LineRenderer _lineRenderer;
    private Gun _gun;

    private int _cnt;
    
    private Transform _targetTrm;
    
    protected override void AfterInit()
    {
        _chainCnt = upgradeValues[UpgradeArrIdx];
        _colliders = new Collider2D[_chainCnt];
        
        _lineRenderer = GetComponentInChildren<LineRenderer>();

        _gun = Player.GetCompo<Gun>();
    }

    protected override void Upgrade()
    {
        _chainCnt = upgradeValues[UpgradeArrIdx];
    }

    public void BulletAbility(Transform targetTrm)
    {
        _targetTrm = targetTrm;
        _cnt = Physics2D.OverlapCircle(_targetTrm.position, _chainRange, fliter, _colliders);

        _lineRenderer.positionCount = _cnt;
        for (int i = 0; i < _cnt; i++)
        {
            if (_colliders[i].gameObject.TryGetComponent(out Health health))
            {
                Debug.Log("이거 개수만큼 맞은거");
                _lineRenderer.SetPosition(i, _colliders[i].transform.position);
                health.TakeDamage(_gun.CurrentAttack * 0.65f,Vector2.zero,Vector2.zero,0);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        if (_targetTrm == null) return;
        Gizmos.DrawWireSphere(_targetTrm.position, _chainRange);
    }
}
