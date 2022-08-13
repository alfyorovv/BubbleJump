using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public Text hpText;
    public Text coinsText;
    public Text scoreText;

    public Player player;
    public Score score;


    void Update()
    {
        hpText.text = "x" + player.hp;
        coinsText.text = "x" + PlayerPrefs.GetInt("coins");
        scoreText.text = (score.score/10).ToString();
}
}
