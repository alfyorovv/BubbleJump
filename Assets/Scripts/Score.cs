using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int score;

    void Start()
    {
        score = 0;
    }

    void Update()
    {
        if (Time.timeScale != 0)
        {
            score++;
        }

        if(score/10 > PlayerPrefs.GetInt("maxScore"))
        {
            PlayerPrefs.SetInt("maxScore", score / 10);
        }
    }
}
