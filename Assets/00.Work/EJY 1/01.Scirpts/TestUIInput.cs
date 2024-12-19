using UnityEngine;

public class TestUIInput : MonoBehaviour
{
    [SerializeField] GameObject setting;
    bool Scene = false;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(Scene == true)
            {
                setting.SetActive(false);
                Scene = false;
                Time.timeScale = 1f;
            }
               
            else
            {
                setting.SetActive(true);
                Scene = true;
                Time.timeScale = 0f;
            }
        }
            
    }
}
