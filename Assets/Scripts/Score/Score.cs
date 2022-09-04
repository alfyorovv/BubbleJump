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
        StartCoroutine(AddScore());
    }

    private void Update()
    {
        if (score > PlayerPrefs.GetInt("maxScore"))
        {
            PlayerPrefs.SetInt("maxScore", score);
        }
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
}
