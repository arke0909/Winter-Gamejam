using UnityEngine;

public class DeadState : EnmyState
{
    public override void OnEnterState()
    {
        _brain.EnemyRIgidCompo.linearVelocity = Vector3.zero;
    }

    public override void OnExitState()
    {

    }

    public override void UpdateState()
    {
        base.UpdateState();
    }

}
