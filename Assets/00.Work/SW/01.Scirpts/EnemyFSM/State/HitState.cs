using System.Collections;
using UnityEngine;

public class HitState : EnmyState
{
    private MoveDecision moveDecision;
    private bool IsHit;
    public override void OnEnterState()
    {
        print("µé¾î¿È");
        if(_brain.EnemyHealthCompo.CurrentHealth <= _brain.EnemyHealthCompo.GetNextHealth())
        {
            _brain.HpBa.SetHpBa();
            if (moveDecision == null)
                foreach (EnemyDecision decision in _decisions)
                    if (decision.GetComponent<MoveDecision>() != null) moveDecision = decision.GetComponent<MoveDecision>();
            _brain.EnemyRIgidCompo.linearVelocity = Vector3.zero;
            _brain.EnemyAnimatorCompo.EnemyAniChange(EnemyAnimation.Hit);
            print(_brain.EnemyHealthCompo.NextHealth);
            _brain.EnemyHealthCompo.NextHealth += _brain.Target.GetComponentInChildren<Gun>().CurrentAttack;

            Vector2 enemyDIr = -(_brain.Target.transform.position - _brain.transform.position).normalized;
            _brain.EnemyHealthCompo.GetKnockback(enemyDIr,5);
        }
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
