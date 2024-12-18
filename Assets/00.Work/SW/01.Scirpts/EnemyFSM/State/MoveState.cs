using UnityEngine;

public class MoveState : EnmyState
{
    private float startTime = 999;
    public override void OnEnterState()
    {

    }

    public override void OnExitState()
    {
        startTime = 0;
    }

    public override void UpdateState()
    {
        Vector2 enemyDIr = (_brain.Target.transform.position - _brain.transform.position).normalized;
        _brain.EnemyRIgid.linearVelocity = new Vector3(enemyDIr.x * _dataSO.moveSpeed, enemyDIr.y * _dataSO.moveSpeed);
        if (startTime >= _dataSO.attackSpeed)
            base.UpdateState();
        else
            startTime += Time.deltaTime;
    }
}
