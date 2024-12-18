using UnityEngine;

public class DeadDecision : EnemyDecision
{
    public override bool MakeDecision()
    {
        return _brain.EnemyDataSO.hp <= 0;
    }
}
