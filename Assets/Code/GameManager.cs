using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject endGamePanel;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timeText;

    void Awake()
    {
        instance = this;
    }

    public void GameOver()
    {
        Time.timeScale = 0f;

        endGamePanel.SetActive(true);

        int finalScore = ScoreManager.instance.score;
        scoreText.text = "Score: " + finalScore;

        GameTimer timer = FindObjectOfType<GameTimer>();
        if (timer != null)
        {
            float t = timer.time;
            int m = Mathf.FloorToInt(t / 60);
            int s = Mathf.FloorToInt(t % 60);

            timeText.text = $"Time: {m:00}:{s:00}";
        }
    }
    public void RestartGame() // 🔥 ต้องมี
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}