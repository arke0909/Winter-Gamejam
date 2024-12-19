using System.Collections;
using UnityEngine;

public class Enemy1AttackState : EnmyState
{
    private MoveDecision moveDecision;
    private float rushDistance = 10;
    [SerializeField] private LayerMask playerLayer;
    public override void OnEnterState()
    {
        _brain.EnemyAnimatorCompo.OnAttackAnimation += Attack;
        _brain.EnemyAnimatorCompo.EnemyAniChange(EnemyAnimation.Attack);
        if (moveDecision == null) 
            foreach(EnemyDecision decision in _decisions )
                if (decision.GetComponent<MoveDecision>() != null) moveDecision = decision.GetComponent<MoveDecision>();

        moveDecision.IsMoveEnd = false;
        _brain.EnemyRIgidCompo.linearVelocity = Vector3.zero;
        Vector2 enemyRushDIr = (_brain.Target.transform.position - _brain.transform.position).normalized;
        _brain.EnemyRIgidCompo.linearVelocity = enemyRushDIr * rushDistance;
        StartCoroutine(StartRushTime());
    }

    private void Attack()
    {
        _brain.DamageCasterCompo.CastDamage(_stat.Damage, 0);
    }

    private IEnumerator StartRushTime()
    {
        yield return new WaitForSeconds(0.25f);
        moveDecision.IsMoveEnd = true;
    }

    public override void OnExitState()
    {
        
    }

    public override void UpdateState()
    {
        base.UpdateState();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position,0.5f);
    }

}
