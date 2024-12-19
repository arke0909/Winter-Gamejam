using GGMPool;
using System.Collections;
using UnityEngine;

public class DeadState : EnmyState
{
    [SerializeField] private PoolManagerSO poolManager;
    public override void OnEnterState()
    {
        _brain.HpBa.SetHpBa();
        _brain.EnemyRIgidCompo.linearVelocity = Vector3.zero;
        _brain.EnemyAnimatorCompo.EnemyAniChange(EnemyAnimation.Dead);
        StartCoroutine(DeadTIme());
    }

    private IEnumerator DeadTIme()
    {
        yield return new WaitForSeconds(0.5f);
        _brain.HpBa.HpReset();
        poolManager.Push(_brain);
    }

    public override void OnExitState()
    {

    }

    public override void UpdateState()
    {
        base.UpdateState();
    }

}
