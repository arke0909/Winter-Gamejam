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
    CatchMe,
    LimeBullet,
    CellBullet,
    Seasoneded,
    BloodedBullet,
}
public class SkillManager : MonoSingleton<SkillManager>
{
    public Action<Transform> OnHit;
    
    private Dictionary<SkillType, Skill> _skills;
    private Player _player;
    private void Awake()
    {
        _skills = new Dictionary<SkillType, Skill>();
    }

    private void Start()
    {
        _player = GameManager.Instance.Player;
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
            _skills.Add(skillType, skill);
        }
    }

    public void GetSkill(SkillType type)
    {
        Debug.Assert(_skills.ContainsKey(type) == true, $"{type} is not Found");

        if (_skills[type].TryGetComponent(out IBulletAble bullet))
        {
            OnHit += bullet.BulletAbility;
        }
        
        _skills[type].UpgradeSkill();
        _skills[type].OnSkill();
    }
}
