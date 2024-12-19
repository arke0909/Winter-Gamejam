using System;
using UnityEngine;

public class PlayerBullet : Bullet
{
    protected override void Awake()
    {
        base.Awake();
        GameManager.Instance.Penetation.OnValueChanged += HandlePenetationCount;
    }

    private void HandlePenetationCount(int prev, int next)
    {
        PenetrationCnt = next;
    }

    protected override void Hit()
    {
        SkillManager.Instance.OnHit?.Invoke();
    }

    private void OnDestroy()
    {
        GameManager.Instance.Penetation.OnValueChanged -= HandlePenetationCount;
    }
}
