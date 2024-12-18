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
    private Dictionary<SkillType, Tuple<Type, Skill>> _skills;
    private Player _player;
    private void Awake()
    {
        _skills = new Dictionary<SkillType, Tuple<Type, Skill>>();
    }

    private void Start()
    {
        foreach (SkillType skillType in Enum.GetValues(typeof(SkillType)))
        {
            Skill skill = GetComponent($"{skillType.ToString()}Skill") as Skill;
            if (skill == null)
            {
                Debug.LogError($"{skillType} is not Found");
                return;
            }
            skill.Initialize(_player);
            Type type = skill.GetType();
            Tuple<Type, Skill> tuple = new Tuple<Type, Skill>(type, skill);
            _skills.Add(skillType, tuple);
        }
    }

    public void GetSkill(SkillType type)
    {
        Debug.Assert(_skills.ContainsKey(type) == true, $"{type} is not Found");
        _skills[type].Item2.OnSkill();
    }
}
