using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePanel : MonoBehaviour
{
    GameObject pausePanel;
    GameObject pauseButton;

    Player player;
    void Start()
    {
        pausePanel = GameObject.Find("PausePanel");
        pauseButton = GameObject.Find("PauseButton");
        pausePanel.SetActive(false);

        player = FindObjectOfType<Player>();
    }

    public void Pause()
    {
            pausePanel.SetActive(true);
            pauseButton.SetActive(false);
            Time.timeScale = 0;
    }

    public void Resume()
    {
        pausePanel.SetActive(false);
        pauseButton.SetActive(true);
        Time.timeScale = 1;
        player.CanJump();
    }

}
