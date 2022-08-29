using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Coins : MonoBehaviour
{
    public Text coinsText;

    void FixedUpdate()
    {
        coinsText.text = "x" + PlayerPrefs.GetInt("coins");
    }
}
