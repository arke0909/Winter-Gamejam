using UnityEngine;
using UnityEngine.UI;

public class PlayerUiSettings : MonoBehaviour
{
    [SerializeField] private Image hpBa;
    [SerializeField] private Image expBa;

    public void HpBaSet(float value)
    {
        hpBa.fillAmount = value;
    }

    public void ExpBaSet(float value)
    {
        expBa.fillAmount = value;
    }
}
