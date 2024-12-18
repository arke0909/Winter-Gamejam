using UnityEngine;

public class AttackState : EnmyState
{
    private MoveDecision moveDecision;
    private float velocityY;
    public override void OnEnterState()
    {
        if (moveDecision == null) 
            foreach(EnemyDecision decision in _decisions )
                if (decision.GetComponent<MoveDecision>() != null) moveDecision = decision.GetComponent<MoveDecision>();

        moveDecision.IsAttackEnd = false;
        velocityY = _brain.EnemyRIgid.linearVelocityY;
        _brain.EnemyRIgid.linearVelocity = Vector3.zero;

    }

    public override void OnExitState()
    {
        
    }

    public override void UpdateState()
    {
        print("Attack");
        base.UpdateState();
    }

}
