using UnityEngine;
using UnityEngine.InputSystem;

public class AdrenalineSkill : Skill
{
    [field: SerializeField]
    private float[] _values = new float[5];

    private Health _health;

    public override void Initialize(Player player)
    {
        base.Initialize(player);

        _health = player.GetComponent<Health>();
    }

    private void Update()
    {
        if(Keyboard.current.digit1Key.wasPressedThisFrame)
            UpgradeSkill();
    }

    protected override void Upgrade()
    {
        _health.UpgradeHealth(_values[UpgradeArrIdx]);
    }
}
