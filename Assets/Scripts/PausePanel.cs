using UnityEngine;

public class PausePanel : MonoBehaviour
{
    private Player player;

    public GameObject pausePanel;
    public GameObject pauseButton;

    private void Awake()
    {
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
        player.SetCanJump(true);
    }

}
