using System.Collections;
using UnityEngine;

public class Enemy3AttackState : EnmyState
{
    private MoveDecision moveDecision;
    [SerializeField] private LayerMask playerLayer;
    public override void OnEnterState()
    {
        _brain.EnemyAnimatorCompo.OnAttackAnimation += Attack;
        _brain.EnemyAnimatorCompo.EnemyAniChange(EnemyAnimation.Attack);
        if (moveDecision == null)
            foreach (EnemyDecision decision in _decisions)
                if (decision.GetComponent<MoveDecision>() != null) moveDecision = decision.GetComponent<MoveDecision>();

        moveDecision.IsMoveEnd = false;
        Vector2 enemyRushDIr = (_brain.Target.transform.position - _brain.transform.position).normalized;
        _brain.EnemyRIgidCompo.linearVelocity = Vector3.zero;
    }

    private void Attack()
    {
        StartCoroutine(StartAttackTime());
    }

    private IEnumerator StartAttackTime()
    {
        if (_brain.DamageCasterCompo.CastDamage(_stat.Damage, 0))
        {
            print("공격성공");
        }
        yield return new WaitForSeconds(0.3f);
        moveDecision.IsMoveEnd = true;
    }

    public override void OnExitState()
    {
        _brain.EnemyAnimatorCompo.OnAttackAnimation -= Attack;
    }

    public override void UpdateState()
    {
        base.UpdateState();
    }
}
