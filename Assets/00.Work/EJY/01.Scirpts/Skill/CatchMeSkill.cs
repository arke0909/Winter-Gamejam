using UnityEngine;
using UnityEngine.InputSystem;

public class CatchMeSkill : Skill
{
    protected override void Upgrade()
    {
        GameManager.Instance.SetHomingValue(true);
    }
}
