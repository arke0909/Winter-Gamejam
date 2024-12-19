using UnityEngine;

public class CatchMeSkill : Skill
{
    protected override void Upgrade()
    {
        GameManager.Instance.SetHomingValue(true);
    }
}
