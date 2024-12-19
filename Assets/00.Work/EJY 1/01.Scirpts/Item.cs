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
}
