using UnityEngine;

public class SeasonededSkill : Skill
{
    [SerializeField] private float[] _values = new float[5];



    protected override void Upgrade()
    {
        GameManager.Instance.SetMultiplyWithExp(_values[UpgradeArrIdx]);
    }
}
