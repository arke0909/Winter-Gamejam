using System;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class Skill : MonoBehaviour
{
    public int CurrentLevel { get; protected set; } = 1;
    [field: SerializeField] public int UpgradeArrIdx { get; protected set; } = 0;

    [field: SerializeField]
    public int MaxLevel { get; protected set; } = 5;
    
    public bool skillEnabled = false;
    
    protected Player Player;

    public virtual void Initialize(Player player)
    {
        Player = player;

        AfterInit();
    }

    protected virtual void AfterInit()
    {
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
        if (!skillEnabled || CurrentLevel >= MaxLevel) return;
        
        CurrentLevel++;
        UpgradeArrIdx++;
        Upgrade();
    }

    protected virtual void Upgrade()
    {
    }

#if UNITY_EDITOR
    protected virtual void Update()
    {
        if(Keyboard.current.digit1Key.wasPressedThisFrame)
            UpgradeSkill();
    }
#endif
}
