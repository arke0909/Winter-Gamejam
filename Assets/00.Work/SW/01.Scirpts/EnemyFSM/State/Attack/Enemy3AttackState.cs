using System.Collections;
using UnityEngine;

public class Enemy3AttackState : EnmyState
{
    private MoveDecision moveDecision;
    [SerializeField] private LayerMask playerLayer;
    public override void OnEnterState()
    {
        if (moveDecision == null)
            foreach (EnemyDecision decision in _decisions)
                if (decision.GetComponent<MoveDecision>() != null) moveDecision = decision.GetComponent<MoveDecision>();

        moveDecision.IsMoveEnd = false;
        _brain.EnemyRIgidCompo.linearVelocity = Vector3.zero;
        Vector2 enemyRushDIr = (_brain.Target.transform.position - _brain.transform.position).normalized;
        StartCoroutine(StartAttackTime());
    }

    private IEnumerator StartAttackTime()
    {
        if(Physics2D.OverlapCircle(transform.position, 0.7f, playerLayer))
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
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, 0.5f);
    }
}
