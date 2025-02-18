using UnityEngine;

public class UISetting : MonoSingleton<UISetting>
{
    [SerializeField] GameObject settingUI;
    public GameObject realQuit;


    private void Awake()
    {
        DontDestroyOnLoad(this);

    }

   
  
    public void Show()
    {
        settingUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Hide()
    {
        settingUI.SetActive(false);
        Time.timeScale = 1f;
    }

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
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(settingUI.activeSelf)
            {
                settingUI.SetActive(false);
                

            }
            else
            {
                settingUI.SetActive(true);
                
            }
        }
    }
}
