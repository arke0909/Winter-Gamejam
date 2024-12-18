using UnityEngine;

public class MoveState : EnmyState
{
    private float moveStartTime = 999;
    private float stopStartTime = 999;
    private bool longRange;
    public override void OnEnterState()
    {
        if(_dataSO.range >= 3) longRange = true;
    }

    public override void OnExitState()
    {
        moveStartTime = 0;
    }

    public override void UpdateState()
    {
        if (longRange)
            if (Vector3.Distance(_brain.transform.position, _brain.Target.transform.position) < _brain.EnemyDataSO.range)
            {
                _brain.EnemyRIgid.linearVelocity = Vector2.zero;
                if (moveStartTime >= _dataSO.attackSpeed)
                    base.UpdateState();
                else
                    moveStartTime += Time.deltaTime;
                return;
            }
        Vector2 enemyDIr = (_brain.Target.transform.position - _brain.transform.position).normalized;
        _brain.EnemyRIgid.linearVelocity = new Vector3(enemyDIr.x * _dataSO.moveSpeed, enemyDIr.y * _dataSO.moveSpeed);
        if (moveStartTime >= _dataSO.attackSpeed)
            base.UpdateState();
        else
            moveStartTime += Time.deltaTime;
    }
}
