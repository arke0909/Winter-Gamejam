using System.Collections;
using UnityEngine;

public class HitState : EnmyState
{
    private MoveDecision moveDecision;
    private bool IsHit;
    public override void OnEnterState()
    {
        if (moveDecision == null)
            foreach (EnemyDecision decision in _decisions)
                if (decision.GetComponent<MoveDecision>() != null) moveDecision = decision.GetComponent<MoveDecision>();
        _brain.EnemyRIgidCompo.linearVelocity = Vector3.zero;
        _brain.EnemyAnimatorCompo.EnemyAniChange(EnemyAnimation.Hit);
        _brain.EnemyHealthCompo.NextHealth += 1;
        print(_brain.EnemyHealthCompo.NextHealth);
        IsHit = true;
        StartCoroutine(HitTime());
    }

    private IEnumerator HitTime()
    {
        yield return new WaitForSeconds(0.2f);
        IsHit = false;
        moveDecision.IsMoveEnd = true;
    }

    public override void OnExitState()
    {

    }

    public override void UpdateState()
    {
        if(!IsHit)
            base.UpdateState();
    }
}
