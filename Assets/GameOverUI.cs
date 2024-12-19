using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI tmp;

    public void GameOver()
    {
        tmp.text = "Score :" +(Time.time).ToString();
        Time.timeScale = 0f;
    }

    public void newGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
