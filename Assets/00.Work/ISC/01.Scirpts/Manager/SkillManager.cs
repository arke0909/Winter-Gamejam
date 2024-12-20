using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

[Serializable]
public enum SkillType
{
    Reload = 0,
    Haste = 1,
    TriggerStrength = 2,
    Adrenaline = 3,
    Penetration= 4,
    ElectronicBullet = 5,
    BoomIsArt = 6,
    CatchMe = 7,
    LimeBullet = 8,
    CellBullet = 9,
    Seasoneded = 10,
    BloodedBullet = 11,
    SummonSamtan = 12,
    SummonBoom = 13,
    SummonSlow = 14,
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
                Debug.Log($"{skillType} is not Found");
                continue;
            }
            skill.Initialize(_player);
            Type type = skill.GetType();
            _skills.Add(skillType, skill);
        }
    }
    
    public void GetSkill(SkillType type)
    {
        
        Debug.Log(type);
        
        if (_skills.ContainsKey(type) == false)
        {
            Debug.Log($"{type} is not Found");
            return;
        }

        if (_skills[type].TryGetComponent(out IBulletAble bullet))
        {
            string str = type.ToString() + "Skill";
            List<IBulletAble> able = _skills[type].GetComponents<IBulletAble>().ToList();
            foreach (var b in able)
            {
                if (str == b.GetType().ToString())
                {
                    OnHit += bullet.BulletAbility;
                }
            }
            
            if (bullet.IsHas)
            {
                Debug.Log($"{type}을 이미 보유중 입니다.");
                
                _skills[type].UpgradeSkill();
                _skills[type].OnSkill();
                return;
            }
        }
        
        _skills[type].UpgradeSkill();
        _skills[type].OnSkill();
    }
}
