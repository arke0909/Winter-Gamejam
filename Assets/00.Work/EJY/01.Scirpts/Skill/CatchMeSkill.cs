using UnityEngine;

public class CatchMeSkill : Skill
{
    protected override void Upgrade()
    {
        Debug.Log("ȣ�� Ȱ��ȭ");
        GameManager.Instance.SetHomingValue(true);
    }
}
