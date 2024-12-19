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
        Time.timeScale = 0f;
    }

    public void Hide()
    { 
        gameObject.SetActive(false);
        Time.timeScale = 1f;
}

    public void Quit()
    {
        Application.Quit();
    }
    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
            Hide();
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
