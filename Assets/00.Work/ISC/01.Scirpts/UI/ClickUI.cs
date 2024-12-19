using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ClickUI : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private TestSkillSO testSkillSo;
    
    public UnityEvent<SkillType, PetType> OnSkillClicked;
    
    public void OnPointerClick(PointerEventData eventData)
    {
        GetComponent<Item>().OnClick();
        OnSkillClicked?.Invoke(testSkillSo.type, testSkillSo.petType);
    }
}
