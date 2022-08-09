using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverPanel : MonoBehaviour
{
    GameObject gameOverPanel;
    void Start()
    {
        gameOverPanel = GameObject.Find("GameOverPanel");
        gameOverPanel.SetActive(false);
    }

   public void GameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }


}
