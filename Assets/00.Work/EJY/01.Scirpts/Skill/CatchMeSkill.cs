using UnityEngine;

public class CatchMeSkill : Skill
{
    protected override void Upgrade()
    {
        Debug.Log("호밍 활성화");
        GameManager.Instance.SetHomingValue(true);
    }
}
