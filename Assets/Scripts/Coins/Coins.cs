using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Coins : MonoBehaviour
{
    public Text coinsText;

    private void Update()
    {
        coinsText.text = "x" + PlayerPrefs.GetInt("coins");
    }
}
