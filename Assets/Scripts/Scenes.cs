using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{

    LoadingScreen loadingScreen;

    void Awake()
    {
        Time.timeScale = 1;
        loadingScreen = FindObjectOfType<LoadingScreen>();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void StartGame()
    {
        StartCoroutine(loadingScreen.LoadSceneAsync());
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
