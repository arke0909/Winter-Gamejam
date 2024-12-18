using System;
using UnityEngine;

public abstract class Skill : MonoBehaviour
{
    public int CurrentLevel { get; protected set; } = 1;
    [field: SerializeField] public int UpgradeArrIdx { get; protected set; } = 0;

    private readonly int _maxLevel = 5;
    
    public bool skillEnabled = false;
    
    protected Player _Player;

    public virtual void Initialize(Player player)
    {
        _Player = player;
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
        UpgradeArrIdx++;
        Upgrade();
    }

    protected virtual void Upgrade()
    {
    }
}
