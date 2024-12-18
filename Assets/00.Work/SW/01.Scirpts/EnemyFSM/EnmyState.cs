using System.Collections.Generic;
using UnityEngine;

public abstract class EnmyState : MonoBehaviour
{
    protected EnemyBrain _brain;
    protected EnemyDataSO _dataSO;
    protected List<EnemyDecision> _decisions;
    public virtual void Init(EnemyBrain brain, EnemyDataSO enemyDataSO)
    {
        _brain = brain;
        _dataSO = enemyDataSO;
        _decisions = new List<EnemyDecision>();
        GetComponentsInChildren(_decisions);
        _decisions.ForEach(decision => decision.Init(brain));
    }
    public abstract void OnEnterState();
    public abstract void OnExitState();
    public virtual void UpdateState()
    {
        foreach (EnemyDecision decision in _decisions)
        {
            if(decision.MakeDecision())
            {
                _brain.ChangeState(decision.NextStste);
            }
        }
    }
}
