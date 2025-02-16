using UnityEngine;

public class UISetting : MonoSingleton<UISetting>
{
    [SerializeField] GameObject settingUI;

    private void Awake()
    {
        DontDestroyOnLoad(this);

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
