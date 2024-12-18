using System.Collections.Generic;
using UnityEngine;

public abstract class EnmyState : MonoBehaviour
{
    protected EnemyBrain _brain;
    protected EnemyStat _stat;
    protected List<EnemyDecision> _decisions;
    public virtual void Init(EnemyBrain brain, EnemyStat enemyStat)
    {
        _brain = brain;
        _stat = enemyStat;
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
