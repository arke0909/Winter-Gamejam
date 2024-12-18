using UnityEngine;

public class MoveState : EnmyState
{
    private float moveStartTime = 999;
    private float stopStartTime = 999;
    private bool longRange;
    public override void OnEnterState()
    {
        if(_stat.Range >= 3) longRange = true;
    }

    public override void OnExitState()
    {
        moveStartTime = 0;
    }

    public override void UpdateState()
    {
        if (longRange)
            if (Vector3.Distance(_brain.transform.position, _brain.Target.transform.position) < _brain.EnemyStatCompo.Range)
            {
                _brain.EnemyRIgidCompo.linearVelocity = Vector2.zero;
                if (moveStartTime >= _stat.AttackSpeed)
                    base.UpdateState();
                else
                    moveStartTime += Time.deltaTime;
                return;
            }
        Vector2 enemyDIr = (_brain.Target.transform.position - _brain.transform.position).normalized;
        _brain.EnemyRIgidCompo.linearVelocity = new Vector3(enemyDIr.x * _stat.MoveSpeed, enemyDIr.y * _stat.MoveSpeed);
        if (moveStartTime >= _stat.AttackSpeed)
            base.UpdateState();
        else
            moveStartTime += Time.deltaTime;
    }
}
