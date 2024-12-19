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
            Debug.Log($"{skillType} initialized");
            Skill skill = GetComponent($"{skillType.ToString()}Skill") as Skill;
            if (skill == null)
            {
                Debug.Log($"{skillType} is not Found");
                continue;
            }
            skill.Initialize(_player);
            Type type = skill.GetType();
            _skills.Add(skillType, skill);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            foreach (SkillType skillType in Enum.GetValues(typeof(SkillType)))
            {
                GetSkill(skillType);
            }
        }
    }

    public void GetSkill(SkillType type)
    {
        if (_skills.ContainsKey(type) == false)
        {
            Debug.Log($"{type} is not Found");
            return;
        }

        if (_skills[type].TryGetComponent(out IBulletAble bullet))
        {
            OnHit += bullet.BulletAbility;
        }
        
        _skills[type].UpgradeSkill();
        _skills[type].OnSkill();
    }
}
