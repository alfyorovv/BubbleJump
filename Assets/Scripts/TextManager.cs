using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public Text hpText;
    public Text coinsText;
    public Player player;


    void Update()
    {
        hpText.text = "HP: " + player.hp;
        coinsText.text = "Coins: " + player.coins;
    }
}
