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
        StartCoroutine(StartAttackTime());
    }

    private IEnumerator StartAttackTime()
    {
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
