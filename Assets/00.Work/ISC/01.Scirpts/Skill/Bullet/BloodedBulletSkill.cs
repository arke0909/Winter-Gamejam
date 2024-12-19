using System;
using System.Collections;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class BloodedBulletSkill : Skill, IBulletAble
{
    [SerializeField] private float[] upgradeValues;
    private float _tickTime;
    
    private float _skillStartTime, _bloodedStartTime, _bloodedDamage;
    private const float BloodedDuration = 5f;
    private int _damageCnt;
    private Coroutine _coroutine;

    private Gun _gun;
    protected override void AfterInit()
    {
        _gun = Player.GetCompo<Gun>();
        
        _bloodedDamage = upgradeValues[UpgradeArrIdx];
    }

    private void Update()
    {
        if (Time.time - _skillStartTime > BloodedDuration)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
    }

    public void BulletAbility(Transform targetTrm)
    {
        if (targetTrm.TryGetComponent<Health>(out Health health))
        {
            _coroutine = StartCoroutine(BloodedCorouine(health));
        }
    }

    private IEnumerator BloodedCorouine(Health health)
    {
        while (true)
        {
            if (Time.time - _bloodedStartTime > BloodedDuration)
            {
                break;
            }
            
            yield return new WaitForSeconds(_tickTime);
            if (_damageCnt > 0)
            {
                health.TakeDamage(_gun.CurrentAttack * _bloodedDamage);
                Debug.Log("아야!");
            }
        }
    }

    protected override void Upgrade()
    {
        _bloodedDamage = upgradeValues[UpgradeArrIdx];
    }
}
