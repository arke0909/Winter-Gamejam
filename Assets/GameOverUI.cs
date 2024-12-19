using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI tmp;
    [SerializeField] GameObject over;
    public GameObject realQuit;
    public void GameOver()
    {
        tmp.text = "Score :" +(Time.time).ToString();
        over.SetActive(true);
        Time.timeScale = 0f;
    }
    public void realShow()
    {
        realQuit.SetActive(true);
    }
    private void Awake()
    {
        over.SetActive(false);
    }
    public void newGame()
    {
        Time.timeScale = 1f;
        over.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void realHide()
    {
        realQuit.SetActive(false);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
