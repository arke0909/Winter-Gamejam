using UnityEngine;

public class PlayerBullet : Bullet
{
    protected override void Hit()
    {
        SkillManager.Instance.OnHit?.Invoke(transform);
    }
}
