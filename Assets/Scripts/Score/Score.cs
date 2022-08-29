using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int score;
    public Text scoreText;

    void Start()
    {
        score = 0;
    }

    void FixedUpdate()
    {
        if (Time.timeScale != 0)
        {
            score++;
        }

        if(score/10 > PlayerPrefs.GetInt("maxScore"))
        {
            PlayerPrefs.SetInt("maxScore", score / 10);
        }
        scoreText.text = (score / 10).ToString();
    }
}
