using UnityEngine;

public class SettingUI : MonoBehaviour
{
   public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide() { gameObject.SetActive(false); }

    public void Quit()
    {
        Application.Quit();
    }
}
