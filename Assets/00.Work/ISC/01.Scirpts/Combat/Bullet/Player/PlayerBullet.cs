using System;
using UnityEngine;

public class PlayerBullet : Bullet
{
    private bool isHoming;

    protected override void Awake()
    {
        base.Awake();
        GameManager.Instance.Penetation.OnValueChanged += HandlePenetationCount;
        GameManager.Instance.IsHoming.OnValueChanged += HandleHoming;
    }

    private void FixedUpdate()
    {
        if (!isHoming) return;


    }

    private void HandleHoming(bool prev, bool next)
    {
        isHoming = next;
    }

    private void HandlePenetationCount(int prev, int next)
    {
        PenetrationCnt = next;
    }

    protected override void Hit()
    {
        SkillManager.Instance.OnHit?.Invoke(transform);
    }

    private void OnApplicationQuit()
    {
        GameManager.Instance.Penetation.OnValueChanged -= HandlePenetationCount;
    }
}
