using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class ReloadSkill : Skill
{
    [field : SerializeField]
    private float[] values = new float[5];

    private Gun _gun;

    public override void Initialize(Player player)
    {
        base.Initialize(player);

        _gun = player.GetCompo<Gun>();
    }

    protected override void Upgrade()
    {
        _gun.ReloadUpgrade(values[UpgradeArrIdx]);
    }
}
