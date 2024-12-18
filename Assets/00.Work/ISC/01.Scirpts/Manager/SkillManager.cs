using System.Collections.Generic;
using UnityEngine;
using System;


public enum SkillType
{
    Reload,
    Haste,
    TriggerStrength,
    Adrenaline,
    Penetration,
    ElectronicBullet,
    BoomIsArt,
    LookLikeLong,
    LimeBullet,
    CellBullet,
    Seasoneded,
    BloodedBullet,
}
public class SkillManager : MonoSingleton<SkillManager>
{
    private Dictionary<Type, Skill> _skills;
    private Player _player;

    private void Awake()
    {
        _skills = new Dictionary<Type, Skill>();
    }

    private void Start()
    {
        foreach (var skillType in Enum.GetValues(typeof(SkillType)))
        {
            Skill skill = GetComponent($"{skillType.ToString()}Skill") as Skill;
            skill.Initialize(_player);
            Type type = skill.GetType();
            
            _skills.Add(type, skill);
        }
    }

    public T GetSkill<T>() where T : Skill
    {
        Type type = typeof(T);

        if (_skills.TryGetValue(type, out Skill targetSkill))
        {
            return targetSkill as T;
        }
        return null;
    }
}
