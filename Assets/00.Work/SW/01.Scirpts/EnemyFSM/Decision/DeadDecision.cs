using UnityEngine;

public class DeadDecision : EnemyDecision
{
    public override bool MakeDecision()
    {
        return _brain.EnemyHealth.GetCurrentHealth() <= 0;
    }
}
