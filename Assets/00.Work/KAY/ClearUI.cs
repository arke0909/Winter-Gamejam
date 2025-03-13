using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearUI : MonoBehaviour
{
    [SerializeField] string startSceneName;
  public void Exit()
    {
        Application.Quit();

    }

    public void ReStart()
    {
        SceneManager.LoadScene(startSceneName);
    }
}
