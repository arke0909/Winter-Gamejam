using System;
using UnityEngine;

public delegate void CooldownInfoEvent(float cureent, float total);
public abstract class Skill : MonoBehaviour
{
    public bool skillEnabled = false;
    [SerializeField] protected float cooldown;
    protected float CooldownTimer;
    protected Player Player;

    public bool IsCooldown => CooldownTimer > 0f;
    public event CooldownInfoEvent OnCooldownInfoEvent;

    public virtual void Initialize(Player player)
    {
        Player = player;
    }

    public void OnSkill()
    {
        skillEnabled = true;
    }

    protected virtual void Update()
    {
        if (CooldownTimer > 0)
        {
            CooldownTimer -= Time.deltaTime;
            
            if (CooldownTimer <= 0)
            {
                CooldownTimer = 0;
            }
            
            OnCooldownInfoEvent?.Invoke(CooldownTimer, cooldown);
        }
    }

    public virtual bool AttemptUseSkill()
    {
        if (CooldownTimer <= 0 && skillEnabled)
        {
            CooldownTimer = cooldown;
            UseSkill();
            return true;
        }
        Debug.Log("Skill cooldown or locked");
        return false;
    }

    public virtual void UseSkill()
    {
    }
}
