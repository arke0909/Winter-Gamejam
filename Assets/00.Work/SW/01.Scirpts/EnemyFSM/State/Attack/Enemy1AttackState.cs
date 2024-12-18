using System.Collections;
using UnityEngine;

public class Enemy1AttackState : EnmyState
{
    private MoveDecision moveDecision;
    private float rushDistance = 10;
    [SerializeField] private LayerMask playerLayer;
    public override void OnEnterState()
    {
        if (moveDecision == null) 
            foreach(EnemyDecision decision in _decisions )
                if (decision.GetComponent<MoveDecision>() != null) moveDecision = decision.GetComponent<MoveDecision>();

        moveDecision.IsMoveEnd = false;
        _brain.EnemyRIgid.linearVelocity = Vector3.zero;

        Vector2 enemyRushDIr = (_brain.Target.transform.position - _brain.transform.position).normalized;
        StartCoroutine(StartRushTime(enemyRushDIr, rushDistance));
        
    }

    private IEnumerator StartRushTime(Vector2 rushDirection, float rushPower)
    {
        _brain.EnemyRIgid.linearVelocity = rushDirection * rushPower;
        if(Physics2D.OverlapCircle(transform.position,0.5f,playerLayer))
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
        Gizmos.DrawWireSphere(transform.position,0.5f);
    }

}
