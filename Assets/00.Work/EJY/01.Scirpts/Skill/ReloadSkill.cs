using UnityEngine;

public class ReloadSkill : Skill
{
    private Gun _gun;

    public override void Initialize(Player player)
    {
        base.Initialize(player);

        _gun = player.GetCompo<Gun>();
    }
}
