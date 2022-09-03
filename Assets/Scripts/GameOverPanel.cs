using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverPanel : MonoBehaviour
{
    public GameObject gameOverPanel;

   public void GameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }


}
