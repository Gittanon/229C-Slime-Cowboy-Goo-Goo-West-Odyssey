using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{
    public float time = 0f;
    public bool isRunning = true;

    public TextMeshProUGUI timerText;

    void Update()
    {
        if (!isRunning) return;

        time += Time.deltaTime;
        UpdateTimerUI();
    }

    void UpdateTimerUI()
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void StopTimer()
    {
        isRunning = false;
    }

    public void StartTimer()
    {
        isRunning = true;
    }

    public void ResetTimer()
    {
        time = 0f;
        UpdateTimerUI();
    }
}