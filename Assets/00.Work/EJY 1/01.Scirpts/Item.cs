using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
   public TestSkillSO testSkillSO;
    public int level;


    [SerializeField]Image icon;
    
    [SerializeField]TextMeshProUGUI levelText;
    [SerializeField]TextMeshProUGUI skillame;
    [SerializeField] TextMeshProUGUI tooltip;
   

    //waepon 이란게 있긴한데..
    void Start()
    {
        
        icon.sprite = testSkillSO.icon;

       
         skillame.text = testSkillSO.skillName;
        tooltip.text=testSkillSO.toolTip;

    }
    
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        levelText.text = "Lv." + (level );
    }
    public void OnClick()
    {
        switch (testSkillSO.type) { 
        case TestSkillSO.skillType.Reload:
            break;
        case TestSkillSO.skillType.Haste:
            break;
        case TestSkillSO.skillType.TriggerStrength:
            break;
        case TestSkillSO.skillType.Adrenaline:
            break;
        case TestSkillSO.skillType.Penetration:
            break;
        case TestSkillSO.skillType.ElectronicBullet:
            break;
        case TestSkillSO.skillType.BoomIsArt:
            break;
        case TestSkillSO.skillType.LookLikeLong:
            break;
        case TestSkillSO.skillType.LimeBullet:
            break;
        case TestSkillSO.skillType.CellBullet:
            break;
        case TestSkillSO.skillType.Seasoneded:
            break;
        case TestSkillSO.skillType.BloodedBullet:
            break;
        case TestSkillSO.skillType.SamTanPet:
            break;
        case TestSkillSO.skillType.BoomPet:
            break;
        case TestSkillSO.skillType.SlowPet:
            break;


        }
        level++;

        
    }
        
    }
