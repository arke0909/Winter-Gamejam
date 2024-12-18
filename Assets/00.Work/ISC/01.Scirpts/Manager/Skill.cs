using System;
using UnityEngine;

public abstract class Skill : MonoBehaviour
{
    public int CurrentLevel { get; protected set; }
    
    private int _maxLevel;
    
    public bool skillEnabled = false;
    
    protected Player Player;

    public virtual void Initialize(Player player)
    {
        Player = player;
    }

    public void OnSkill()
    {
        skillEnabled = true;
        Upgrade();
    }

    public virtual void UseSkill()
    {
    }

    public void UpgradeSkill()
    {
        if (!skillEnabled || CurrentLevel >= _maxLevel) return;
        
        CurrentLevel++;
        Upgrade();
    }

    protected virtual void Upgrade()
    {
    }
}
