using UnityEngine;

public class MoveState : EnmyState
{
    public override void OnEnterState()
    {

    }

    public override void OnExitState()
    {

    }

    public override void UpdateState()
    {
        print("Move");
        Vector2 enemyDIr = (_brain.Target.transform.position - _brain.transform.position).normalized;
        _brain.EnemyRIgid.linearVelocity = new Vector3(enemyDIr.x * _dataSO.moveSpeed, enemyDIr.y * _dataSO.moveSpeed);
        base.UpdateState();
    }
}
