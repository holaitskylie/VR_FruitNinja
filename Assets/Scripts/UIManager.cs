using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<UIManager>();
            }

            return instance;
        }
    }

    private static UIManager instance;

    public Text timeText;
    public Text scoreText;
    int score = 0;    

    private void Update()
    {
        if (!GameManager.instance.isGameover)
        {
            int intTimer = (int)GameManager.instance.timer;
            timeText.text = "TIME " + intTimer.ToString();
        }
    }

    public void UpdateScore(int newScore)
    {
        if (!GameManager.instance.isGameover)
        {
            score += newScore;
            scoreText.text = "" + score;

        }

        scoreText.text = "" + score;
    }

    public void SetActiveGameoverUI()
    {
        if (GameManager.instance.isGameover)
        {
            timeText.text = "GAME OVER!!";

        }        
    }
}
