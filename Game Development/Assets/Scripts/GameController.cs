using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    public float levelTime = 120.0f;
    private float currentTime;
    public Text timerText;
    public GameObject gameOverPanel;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        currentTime = levelTime;
    }

    void Update()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;

            int minutes = Mathf.FloorToInt(currentTime / 60F);
            int seconds = Mathf.FloorToInt(currentTime - minutes * 60);
            string formattedTime = string.Format("{0:0}:{1:00}", minutes, seconds);

            timerText.text = "Time Remaining: " + formattedTime;
        }
        else
        {
            GameOver();
        }
    }

    public void GameWin()
    {
        // Implement win logic
    }

    void GameOver()
    {
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
    }

    public void ExtendTime(float timeToAdd)
    {
        currentTime += timeToAdd;
        timerText.text = "Time Remaining: " + currentTime.ToString("F2");
    }
}