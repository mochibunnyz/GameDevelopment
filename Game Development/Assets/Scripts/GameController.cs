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
            timerText.text = "Time Remaining: " + currentTime.ToString("F2");
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
        // Implement game over logic
    }
}