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
        hpText.text = "HP: " + player.hp;
        coinsText.text = "Coins: " + PlayerPrefs.GetInt("coins");
        scoreText.text = (score.score/10).ToString();
}
}
