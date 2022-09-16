using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverPanel : MonoBehaviour
{
    public GameObject gameOverPanel;
    Score score;

    private void Awake()
    {
        score = FindObjectOfType<Score>();
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        score.scoreText.fontSize = 48;
        Time.timeScale = 0;

        if (score.IsNewScore())
        {
            score.scoreText.text = "New best: " + score.score + "!";
        }
        else
        {
            score.scoreText.text = "Your score: " + score.score;
        }

        
    }


}
