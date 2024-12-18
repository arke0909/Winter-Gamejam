using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "TestSkillSO", menuName = "SO/TestSkillSO")]
public class TestSkillSO : ScriptableObject
{
    public enum skillType {
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
        SamTanPet,
        BoomPet,
        SlowPet,
    }
    [Header("#Main Info")]
    public skillType type;
    public string toolTip;
    public string skillName;
    public Sprite icon;
    public int itemId;
   

}
