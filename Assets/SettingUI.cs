using UnityEngine;

public class SettingUI : MonoBehaviour
{
    public GameObject realQuit;

    private void Awake()
    {
        realQuit.SetActive(false);
        if(!(gameObject.name == "StartUI"))
            gameObject.SetActive(false);



    }
    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide() { gameObject.SetActive(false); }

    public void Quit()
    {
        Application.Quit();
    }

    public void realShow()
    {
        realQuit.SetActive(true);
    }
    
    public void realHide()
    {
        realQuit.SetActive(false);
    }
}   
