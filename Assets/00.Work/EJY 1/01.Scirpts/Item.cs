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

    private void OnEnable()
    {
        levelText.text = "Lv." + level;

    }

   
  
    public void OnClick()
    {
        switch (testSkillSO.type) { 
        case TestSkillSO.skillType.Reload:
                if (level == 0)
                {
                    //0에서 1로 => 증강이 처음으로 선택되어 추가되어야 할때 써야할 로직
                }
                else
                {
                    //이후 로직.. 
                }
            break;
        case TestSkillSO.skillType.Haste:
                if (level == 0)
                {
                    //0에서 1로 => 증강이 처음으로 선택되어 추가되어야 할때 써야할 로직
                }
                else
                {
                    //이후 로직.. 
                }
                break;
        case TestSkillSO.skillType.TriggerStrength:
                if (level == 0)
                {
                    //0에서 1로 => 증강이 처음으로 선택되어 추가되어야 할때 써야할 로직
                }
                else
                {
                    //이후 로직.. 
                }
                break;
        case TestSkillSO.skillType.Adrenaline:
                if (level == 0)
                {
                    
                }
                break;
        case TestSkillSO.skillType.Penetration:
                if (level == 0)
                {

                }
                break;
        case TestSkillSO.skillType.ElectronicBullet:
                if (level == 0)
                {

                }
                break;
        case TestSkillSO.skillType.BoomIsArt:
                if (level == 0)
                {

                }
                break;
        case TestSkillSO.skillType.LookLikeLong:
                if (level == 0)
                {

                }
                break;
        case TestSkillSO.skillType.LimeBullet:
                if (level == 0)
                {

                }
                break;
        case TestSkillSO.skillType.CellBullet:
                if (level == 0)
                {

                }
                break;
        case TestSkillSO.skillType.Seasoneded:
                if (level == 0)
                {

                }
                break;
        case TestSkillSO.skillType.BloodedBullet:
                if (level == 0)
                {

                }
                break;
        case TestSkillSO.skillType.SamTanPet:
                if (level == 0)
                {

                }
                break;
        case TestSkillSO.skillType.BoomPet:
                if (level == 0)
                {

                }
                break;
        case TestSkillSO.skillType.SlowPet:
                if (level == 0)
                {

                }
                break;


        }
        level++; //로직 끝나고 레벨값이 오릅니다~

        
    }
        
    }
