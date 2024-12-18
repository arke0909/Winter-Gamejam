using UnityEngine;

public class AttackDecision : EnemyDecision
{
    public override bool MakeDecision()
    {
        return Vector3.Distance(_brain.transform.position,_brain.Target.transform.position) < _brain.EnemyDataSO.range;
    }
}
