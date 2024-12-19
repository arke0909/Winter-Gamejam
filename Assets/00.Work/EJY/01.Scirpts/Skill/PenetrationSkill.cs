using UnityEngine;
using UnityEngine.InputSystem;

public class PenetrationSkill : Skill
{
    [field: SerializeField] private int[] _values = new int[5];

    protected override void Upgrade()
    {
        GameManager.Instance.SetPenetation(_values[UpgradeArrIdx]);
    }
}
