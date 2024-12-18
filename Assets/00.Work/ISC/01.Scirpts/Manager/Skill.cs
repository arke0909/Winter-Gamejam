using System;
using UnityEngine;

public abstract class Skill : MonoBehaviour
{
    [field : SerializeField]
    public int CurrentLevel { get; protected set; }
    
    private readonly int _maxLevel = 5;
    
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
