using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaxScore : MonoBehaviour
{
    public Text maxScoreText;

    void Update()
    {
        maxScoreText.text = "Best score: " + PlayerPrefs.GetInt("maxScore").ToString();
    }
}
