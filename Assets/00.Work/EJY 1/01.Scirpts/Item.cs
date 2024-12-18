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

   
    //waepon �̶��� �ֱ��ѵ�..
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
                    //0���� 1�� => ������ ó������ ���õǾ� �߰��Ǿ�� �Ҷ� ����� ����
                }
                else
                {
                    //���� ����.. 
                }
            break;
        case TestSkillSO.skillType.Haste:
                if (level == 0)
                {
                    //0���� 1�� => ������ ó������ ���õǾ� �߰��Ǿ�� �Ҷ� ����� ����
                }
                else
                {
                    //���� ����.. 
                }
                break;
        case TestSkillSO.skillType.TriggerStrength:
                if (level == 0)
                {
                    //0���� 1�� => ������ ó������ ���õǾ� �߰��Ǿ�� �Ҷ� ����� ����
                }
                else
                {
                    //���� ����.. 
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
        level++; //���� ������ �������� �����ϴ�~

        
    }
        
    }
