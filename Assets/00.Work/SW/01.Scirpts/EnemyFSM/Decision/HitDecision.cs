using UnityEngine;

public class HitDecision : EnemyDecision
{
    public override bool MakeDecision()
    {
        return _brain.EnemyHealthCompo.CurrentHealth <= _brain.EnemyHealthCompo.GetNextHealth() && !(_brain.EnemyHealthCompo.GetCurrentHealth() <= 0);
    }
}
