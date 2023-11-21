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
    public int score = 0;    

    private void Update()
    {
        if (!GameManager.Instance.isGameover)
        {
            int intTimer = (int)GameManager.Instance.timer;
            timeText.text = "TIME " + intTimer.ToString();
        }
    }

    public void UpdateScore(int newScore)
    {
        if (!GameManager.Instance.isGameover)
        {
            score += newScore;
            scoreText.text = "" + score;

        }

        scoreText.text = "" + score;
    }

    public void SetActiveGameoverUI()
    {
        if (GameManager.Instance.isGameover)
        {
            timeText.text = "GAME OVER!!";

        }        
    }
}
