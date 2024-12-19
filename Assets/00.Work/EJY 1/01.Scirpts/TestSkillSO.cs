using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "TestSkillSO", menuName = "SO/TestSkillSO")]
public class TestSkillSO : ScriptableObject
{
    [Header("#Main Info")]
    public PetType petType;
    public SkillType type;
    public string toolTip;
    public string skillName;
    public Sprite icon;
    public int itemId;
   

}
