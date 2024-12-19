using System;
using System.Collections;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class BloodedBulletSkill : Skill, IBulletAble
{
    [SerializeField] LayerMask whatIsEnemy;
    [SerializeField] private float[] upgradeValues;
    private float _tickTime = 0.5f;
    
    private float _bloodedStartTime, _bloodedDamage;
    private const float BloodedDuration = 3f;
    private int _damageCnt = 5;
    private Coroutine _coroutine;

    private bool _isActive = false;
    
    private Gun _gun;
    
    private Transform _targetTrm;

    private Collider2D _collider;
    protected override void AfterInit()
    {
        _gun = Player.GetCompo<Gun>();
        
        _bloodedDamage = upgradeValues[UpgradeArrIdx];
    }

    public void BulletAbility(Transform targetTrm)
    {
        _targetTrm = targetTrm;
        _collider = Physics2D.OverlapCircle(_targetTrm.position, 0.6f, whatIsEnemy);

        if (_collider != null)
        {
            if (_collider.gameObject.TryGetComponent<Health>(out Health health))
            {
                if (_coroutine != null)
                {
                    _bloodedStartTime = Time.time;
                    _damageCnt = 5;
                    return;
                }
                _coroutine = StartCoroutine(BloodedCoroutine(health));
            }
        }
    }

    private IEnumerator BloodedCoroutine(Health health)
    {
        _isActive = true;
        _bloodedStartTime = Time.time;
        while (true)
        {
            if (_bloodedStartTime - Time.time > BloodedDuration && _damageCnt <= 0)
            {
                _damageCnt = 5;
                _coroutine = null;
                _collider = null;
                _isActive = false;
                _targetTrm = null;
                break;
            }
            
            yield return new WaitForSeconds(_tickTime);
            if (_damageCnt > 0 && _isActive)
            {
                Debug.Log("아야!");
                health.TakeDamage(_gun.CurrentAttack * _bloodedDamage, Vector2.zero, Vector2.zero);
                _damageCnt--;
            }
        }
    }

    protected override void Upgrade()
    {
        _bloodedDamage = upgradeValues[UpgradeArrIdx];
    }

    private void OnDrawGizmos()
    {
        if (_targetTrm == null) return;
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(_targetTrm.position, 0.6f);
        Gizmos.color = Color.white;
    }
}
