using UnityEngine;

public class ElectronicBulletSkill : Skill, IBulletAble
{
    [SerializeField] private float _chainRange;
    private int _chainCnt = 3;
    [SerializeField] private int[] upgradeValues;
    [SerializeField] private ContactFilter2D fliter;
    Collider2D[] _colliders;
    
    private LineRenderer _lineRenderer;
    
    protected override void AtferInit()
    {
        _chainCnt = upgradeValues[UpgradeArrIdx];
        _colliders = new Collider2D[_chainCnt];
        
        _lineRenderer = GetComponentInChildren<LineRenderer>();
    }

    protected override void Upgrade()
    {
        _chainCnt = upgradeValues[UpgradeArrIdx];
    }

    public void BulletAbility(Transform targetTrm)
    {
        int cnt = Physics2D.OverlapCircle(targetTrm.position, _chainRange, fliter, _colliders);

        for (int i = 0; i < cnt; i++)
        {
            if (_colliders[i].gameObject.TryGetComponent(out Health health))
            {
                _lineRenderer.SetPosition(i, _colliders[i].transform.position);
                health.TakeDamage(_Player);
            }
        }
    }
}
