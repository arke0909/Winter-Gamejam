using UnityEngine;

public class TriggerStrengthSkill : Skill
{
    [field: SerializeField]
    public float[] values = new float[5];

    private Gun _gun;

    public override void Initialize(Player player)
    {
        base.Initialize(player);

        _gun = player.GetCompo<Gun>();
    }

    protected override void Upgrade()
    {
        _gun.AttackUpgrade(values[UpgradeArrIdx]);
    }
}
