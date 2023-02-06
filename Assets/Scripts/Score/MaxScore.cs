using UnityEngine;
using UnityEngine.UI;

public class MaxScore : MonoBehaviour
{
    public Text maxScoreText;

    private void Update()
    {
        maxScoreText.text = "Best score: " + PlayerPrefs.GetInt("maxScore").ToString();
    }
}
