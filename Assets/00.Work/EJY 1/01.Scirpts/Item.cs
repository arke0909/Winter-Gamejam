using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public TestSkillSO testSkillSO;
    public int level;


    [SerializeField] Image icon;

    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] TextMeshProUGUI skillame;
    [SerializeField] TextMeshProUGUI tooltip;


    //waepon �̶��� �ֱ��ѵ�..
    void Start()
    {

        icon.sprite = testSkillSO.icon;


        skillame.text = testSkillSO.skillName;
        tooltip.text = testSkillSO.toolTip;

    }

    private void OnEnable()
    {
        levelText.text = "Lv." + level;

    }

    public void OnClick()
    {
        switch (testSkillSO.type)
        {
            case SkillType.Reload:
                if (level == 0)
                {
                    //0���� 1�� => ������ ó������ ���õǾ� �߰��Ǿ�� �Ҷ� ����� ����
                }
                else
                {
                    //���� ����.. 
                }
                break;
            case SkillType.Haste:
                if (level == 0)
                {
                    //0���� 1�� => ������ ó������ ���õǾ� �߰��Ǿ�� �Ҷ� ����� ����
                }
                else
                {
                    //���� ����.. 
                }
                break;
            case SkillType.TriggerStrength:
                if (level == 0)
                {
                    //0���� 1�� => ������ ó������ ���õǾ� �߰��Ǿ�� �Ҷ� ����� ����
                }
                else
                {
                    //���� ����.. 
                }
                break;
            case SkillType.Adrenaline:
                if (level == 0)
                {

                }
                break;
            case SkillType.Penetration:
                if (level == 0)
                {

                }
                break;
            case SkillType.ElectronicBullet:
                if (level == 0)
                {

                }
                break;
            case SkillType.BoomIsArt:
                if (level == 0)
                {

                }
                break;
            case SkillType.CatchMe:
                if (level == 0)
                {

                }
                break;
            case SkillType.LimeBullet:
                if (level == 0)
                {

                }
                break;
            case SkillType.CellBullet:
                if (level == 0)
                {

                }
                break;
            case SkillType.Seasoneded:
                if (level == 0)
                {

                }
                break;
            case SkillType.BloodedBullet:
                if (level == 0)
                {

                }
                break;
            case SkillType.SummonSamtan:
                if (level == 0)
                {

                }
                break;
            case SkillType.SummonBoom:
                if (level == 0)
                {

                }
                break;
            case SkillType.SummonSlow:
                if (level == 0)
                {

                }
                break;
        }
        if (level < 5)
            level++; //���� ������ �������� �����ϴ�~
    }
}
