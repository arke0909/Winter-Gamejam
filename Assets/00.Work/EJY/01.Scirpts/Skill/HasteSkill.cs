using UnityEngine;
using UnityEngine.InputSystem;

public class HasteSkill : Skill
{
    [field : SerializeField]
    private float[] _values = new float[5];
    private PlayerMover _playerMover;

    public override void Initialize(Player player)
    {
        base.Initialize(player);

        _playerMover = player.GetCompo<PlayerMover>();
    }

    protected override void Upgrade()
    {
        _playerMover.SetSpeed(_values[UpgradeArrIdx]);
    }
}
