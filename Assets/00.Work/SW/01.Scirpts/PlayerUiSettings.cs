using UnityEngine;
using UnityEngine.UI;

public class PlayerUiSettings : MonoBehaviour
{
    [SerializeField] private Image hpBa;
    [SerializeField] private Image expBa;
    [SerializeField] private Health playerHealth;
    private void HpBaSet(float value)
    {
        hpBa.fillAmount = value;
    }

    private void ExpBaSet(float value)
    {
        expBa.fillAmount = value;
    }

    private void Update()
    {
        HpBaSet(playerHealth.CurrentHealth/playerHealth.MaxHealth);
        ExpBaSet(1 - GameManager.Instance.EXP/100);
    }
}
