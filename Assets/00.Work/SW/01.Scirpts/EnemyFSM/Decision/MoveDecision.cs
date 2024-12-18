using UnityEngine;

public class MoveDecision : EnemyDecision
{
    public bool IsMoveEnd {  get; set; }
    public override bool MakeDecision()
    {
        if (IsMoveEnd)
        {
            IsMoveEnd = false;
            return true;
        }

        return false;
    }
}
