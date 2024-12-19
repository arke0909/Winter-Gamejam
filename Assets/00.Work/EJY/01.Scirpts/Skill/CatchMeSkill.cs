using UnityEngine;
using UnityEngine.InputSystem;

public class CatchMeSkill : Skill
{
    private void Update()
    {
        if (Keyboard.current.digit1Key.wasPressedThisFrame)
            OnSkill();
    }

    protected override void Upgrade()
    {
        GameManager.Instance.SetHomingValue(true);
    }
}
