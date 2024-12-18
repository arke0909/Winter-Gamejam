using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class ReloadSkill : Skill
{
    [field : SerializeField]
    public float[] values = new float[5];

    private Gun _gun;

    public override void Initialize(Player player)
    {
        base.Initialize(player);

        _gun = player.GetCompo<Gun>();
    }

    private void Update()
    {
        if (Keyboard.current.digit1Key.wasPressedThisFrame)
        {
            Upgrade();
        }
    }

    protected override void Upgrade()
    {
        _gun.ReloadUpgrade(values[CurrentLevel]);
    }
}
