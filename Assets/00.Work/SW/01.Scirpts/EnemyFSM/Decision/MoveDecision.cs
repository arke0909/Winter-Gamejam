using UnityEngine;

public class MoveDecision : EnemyDecision
{
    public bool IsAttackEnd {  get; set; }
    public override bool MakeDecision()
    {
        if (IsAttackEnd)
        {
            IsAttackEnd = false;
            return true;
        }

        return false;
    }
}
