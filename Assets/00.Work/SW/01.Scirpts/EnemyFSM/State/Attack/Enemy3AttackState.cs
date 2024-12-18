using System.Collections;
using UnityEngine;

public class Enemy3AttackState : EnmyState
{
    private MoveDecision moveDecision;
    public override void OnEnterState()
    {
        if (moveDecision == null)
            foreach (EnemyDecision decision in _decisions)
                if (decision.GetComponent<MoveDecision>() != null) moveDecision = decision.GetComponent<MoveDecision>();

        moveDecision.IsMoveEnd = false;
        _brain.EnemyRIgid.linearVelocity = Vector3.zero;
        Vector2 enemyRushDIr = (_brain.Target.transform.position - _brain.transform.position).normalized;
        StartCoroutine(StartAttackTime(enemyRushDIr,0.2f));
    }

    private IEnumerator StartAttackTime(Vector2 attackDirection, float attackPower)
    {
        if(Physics2D.Raycast(transform.position, attackDirection, attackPower))
        {
            print("공격성공");
        }
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
