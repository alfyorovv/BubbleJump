using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverPanel : MonoBehaviour
{
    public GameObject gameOverPanel;
    Score score;
    InterstitialAds ad;

    private void Awake()
    {
        score = FindObjectOfType<Score>();
        ad = FindObjectOfType<InterstitialAds>();
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

        if (PlayerPrefs.GetInt("tempAds") > 3)
        {
            PlayerPrefs.SetInt("tempAds", 0);
            ad.ShowAd();
        }
    }


}
