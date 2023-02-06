using UnityEngine;

public class GameOverPanel : MonoBehaviour
{
    private PausePanel pausePanel;
    private Score score;
    private InterstitialAds ad;

    public GameObject gameOverPanel;

    private void Awake()
    {
        score = FindObjectOfType<Score>();
        ad = FindObjectOfType<InterstitialAds>();
        pausePanel = FindObjectOfType<PausePanel>();
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        pausePanel.pauseButton.SetActive(false);
        score.scoreText.fontSize = 48;

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
        Time.timeScale = 0;
    }


}
