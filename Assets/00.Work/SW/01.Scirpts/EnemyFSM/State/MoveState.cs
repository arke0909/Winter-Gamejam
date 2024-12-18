using UnityEngine;

public class MoveState : EnmyState
{
    private float startTime = 999;
    private bool longRange;
    public override void OnEnterState()
    {
        if(_dataSO.range >= 3) longRange = true;
    }

    public override void OnExitState()
    {
        startTime = 0;
    }

    public override void UpdateState()
    {
        if (longRange)
            if (Vector3.Distance(_brain.transform.position, _brain.Target.transform.position) < _brain.EnemyDataSO.range)
            {
                _brain.EnemyRIgid.linearVelocity = Vector2.zero;
                return;
            }
        Vector2 enemyDIr = (_brain.Target.transform.position - _brain.transform.position).normalized;
        _brain.EnemyRIgid.linearVelocity = new Vector3(enemyDIr.x * _dataSO.moveSpeed, enemyDIr.y * _dataSO.moveSpeed);
        if (startTime >= _dataSO.attackSpeed)
            base.UpdateState();
        else
            startTime += Time.deltaTime;
    }
}
