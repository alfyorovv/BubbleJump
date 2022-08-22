using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinsShop : MonoBehaviour
{
    public GameObject playButton;
    public GameObject buyButton;
    public GameObject backButton;
    public GameObject prevSkinButton;
    public GameObject nextSkinButton;
    private void Start()
    {
        
    }
    public void ChangeSkinButtonClicked()
    {
        playButton.SetActive(false);
        buyButton.SetActive(true);
        backButton.SetActive(true);
        prevSkinButton.SetActive(true);
        nextSkinButton.SetActive(true);
    }

    public void BackButtonClicked()
    {
        playButton.SetActive(true);
        buyButton.SetActive(false);
        backButton.SetActive(false);
        prevSkinButton.SetActive(false);
        nextSkinButton.SetActive(false);
    }
}
