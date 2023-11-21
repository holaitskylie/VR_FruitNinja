using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool isGameover = false;

    public float timer = 60;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            isGameover = true;
            EndGame();
        }

        
    }

    public void AddScore(int newScore)
    {
        UIManager.Instance.UpdateScore(newScore);

        if(UIManager.Instance.score % 100 == 0)
        {
            Spawn spawn = FindObjectOfType<Spawn>();
            if(spawn != null)
            {
                spawn.DecreaseInterval();
                Debug.Log("Level Upgrade");
            }
        }

    }

    public void EndGame()
    {        
        if(isGameover)
        {
            UIManager.Instance.SetActiveGameoverUI();

            //과일 스폰 멈추기
            FruitSpawner spawn = FindObjectOfType<FruitSpawner>();
            spawn.enabled = false;

        }       
    }
}
