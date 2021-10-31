using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    int Score = 0;
    int lives = 3;
    public Text ScoreText;
    public GameObject livesHolder;
    public GameObject gameOverPanel;
    public static GameManager instance;
    
    bool gameOver = false;
    private void Awake()
    {
        instance = this;
    }
    public void IncreaseScore()
    {
        if (!gameOver)
        {
            Score++;
            ScoreText.text = Score.ToString();
            //print(Score);
        }

    }
    public void DecreaseLife()
    {
        if (lives > 0)
        {
            lives--;
            print(lives);
            livesHolder.transform.GetChild(lives).gameObject.SetActive(false);
        }
        if (lives <= 0)
        {
            gameOver = true;
            GameOver();
        }
    }
    public void GameOver()
    {
        CandySpawn.instance.Stopspawn();
        GameObject.Find("Player").GetComponent<PlayerController>().canMove = false;
        gameOverPanel.SetActive(true);
        print("GameOver()");
    }
    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }
    public void BackToManu()
    {
        SceneManager.LoadScene("Manu");
    }
}
