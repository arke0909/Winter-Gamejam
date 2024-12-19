using UnityEngine;

public class MoveState : EnmyState
{
    private float moveStartTime = 999;
    private float stopStartTime = 999;
    private bool longRange;
    public override void OnEnterState()
    {
        if(_stat.Range >= 3) longRange = true;
        _brain.EnemyAnimatorCompo.EnemyAniChange(EnemyAnimation.Move);
    }

    public override void OnExitState()
    {
        moveStartTime = 0;
    }

    public override void UpdateState()
    {
        Vector2 enemyDIr = (_brain.Target.transform.position - _brain.transform.position).normalized;
        if (Vector3.Distance(_brain.transform.position, _brain.Target.transform.position) < _brain.EnemyStatCompo.Range)
        {
            _brain.EnemyRIgidCompo.linearVelocity = Vector2.zero;
            _brain.EnemyAnimatorCompo.Flip(enemyDIr.x);
            _brain.EnemyAnimatorCompo.EnemyAniChange(EnemyAnimation.Idie);
            if (moveStartTime >= _stat.AttackSpeed)
                base.UpdateState();
            else
                moveStartTime += Time.deltaTime;

            return;
        }


        if (_brain._CanMove)
        {
            _brain.EnemyAnimatorCompo.EnemyAniChange(EnemyAnimation.Move);
            _brain.EnemyRIgidCompo.linearVelocity = new Vector3(enemyDIr.x * _stat.MoveSpeed, enemyDIr.y * _stat.MoveSpeed);
            _brain.EnemyAnimatorCompo.Flip(enemyDIr.x);
        }
        if (moveStartTime >= _stat.AttackSpeed)
            base.UpdateState();
        else
            moveStartTime += Time.deltaTime;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _brain.EnemyStatCompo.Range);
    }
}
