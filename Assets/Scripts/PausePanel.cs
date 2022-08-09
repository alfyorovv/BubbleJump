using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePanel : MonoBehaviour
{
    GameObject pausePanel;
    GameObject pauseButton;
    void Start()
    {
        pausePanel = GameObject.Find("PausePanel");
        pauseButton = GameObject.Find("PauseButton");
        pausePanel.SetActive(false);
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
    }

}
