using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int score;
    public Text scoreText;

    private void Awake()
    {
        score = 0;
    }

    private void Start()
    {
        StartCoroutine(AddScore());
    }

    private void Update()
    {
        scoreText.text = score.ToString();
    }

    IEnumerator AddScore()
    {
        while(Time.timeScale > 0)
        {
            score++;
            yield return new WaitForSeconds(0.1f);
        }
    }

    public bool IsNewScore()
    {
        if (score >= PlayerPrefs.GetInt("maxScore"))
        {
            Debug.Log("New score: " + score);
            PlayerPrefs.SetInt("maxScore", score);
            return true;
        }
        else
        {
            Debug.Log("Your score: " + score);
            return false;
        }
    }
}
