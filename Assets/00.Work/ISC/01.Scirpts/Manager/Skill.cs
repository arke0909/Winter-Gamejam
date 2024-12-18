using System;
using UnityEngine;

public abstract class Skill : MonoBehaviour
{
    public bool skillEnabled = false;
    
    protected Player Player;

    public virtual void Initialize(Player player)
    {
        Player = player;
    }

    public void OnSkill()
    {
        skillEnabled = true;
    }

    public virtual void UseSkill()
    {
    }
}
