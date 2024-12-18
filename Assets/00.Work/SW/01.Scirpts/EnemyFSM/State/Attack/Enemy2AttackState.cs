using GGMPool;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy2AttackState : EnmyState
{
    private MoveDecision moveDecision;
    [SerializeField] private PoolTypeSO poolType;
    [SerializeField] private PoolManagerSO poolManager;
    public override void OnEnterState()
    {
        if (moveDecision == null)
            foreach (EnemyDecision decision in _decisions)
                if (decision.GetComponent<MoveDecision>() != null) moveDecision = decision.GetComponent<MoveDecision>();

        moveDecision.IsMoveEnd = false;
        _brain.EnemyRIgidCompo.linearVelocity = Vector3.zero;
        StartCoroutine(StartAttackTime());
    }

    private IEnumerator StartAttackTime()
    {
        Bullet poolable = poolManager.Pop(poolType) as Bullet;
        Vector2 bulletDir = _brain.Target.transform.position - transform.position;
        poolable.Initialize(transform.position,bulletDir);
        yield return new WaitForSeconds(0.2f);
        moveDecision.IsMoveEnd = true;
    }

    public override void OnExitState()
    {

    }

    public override void UpdateState()
    {
        base.UpdateState();
    }
}
