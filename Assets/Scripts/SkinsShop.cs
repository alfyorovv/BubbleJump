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
    public GameObject equipButton;

    int currentSkin;
    SpriteRenderer sr;
    public Sprite[] skins;
    public int[] prices;

    private void Awake()
    {
        currentSkin = PlayerPrefs.GetInt("currentSkin");
        sr = GameObject.Find("MainMenuPlayer").GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        SkinPreview();
    }

    //Refactoring required
    public void ChangeSkinButtonClicked()
    {
        playButton.SetActive(false);
        buyButton.SetActive(true);
        backButton.SetActive(true);
        prevSkinButton.SetActive(true);
        nextSkinButton.SetActive(true);
        equipButton.SetActive(false);

        HideArrows();
        HideBuyButton();
    }

    public void BackButtonClicked()
    {
        playButton.SetActive(true);
        buyButton.SetActive(false);
        backButton.SetActive(false);
        prevSkinButton.SetActive(false);
        nextSkinButton.SetActive(false);
    }

    public void EquipButtonClicked()
    {
        equipButton.SetActive(false);
        PlayerPrefs.SetInt("currentSkin", currentSkin);
        SkinPreview();
    }

    public void NextSkinButtonClicked()
    {
        currentSkin+=2; //We have 2 sprites on player, +2 to iterate every pair
        HideArrows();
        SkinPreview();
        HideBuyButton();
    }

    public void PrevSkinButtonClicked()
    {
        currentSkin-=2; //We have 2 sprites on player, -2 to iterate every pair
        HideArrows();
        SkinPreview();
        HideBuyButton();
    }

    void HideArrows()
    {
        if (currentSkin == 0)
        {
            prevSkinButton.SetActive(false);
        }
        else
        {
            prevSkinButton.SetActive(true);

        }

        if (currentSkin == skins.Length) //currentSkin have step 2 and reaching end when equals array lenght
        {
            nextSkinButton.SetActive(false);
        }
        else
        {
            nextSkinButton.SetActive(true);
        }

    }

    public void BuyButtonClicked()
    {
        if(PlayerPrefs.GetInt("coins") > prices[currentSkin/2])
        {
            PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins") - prices[currentSkin / 2]); //Subtract price from coins
            buyButton.SetActive(false);
            equipButton.SetActive(true);
            PlayerPrefs.SetInt("isBought" + currentSkin / 2, true? 1 : 0);
        }
    }

    void SkinPreview()
    {
        sr.sprite = skins[currentSkin/2];
    }

    bool IsBought()
    {
        return PlayerPrefs.GetInt("isBought"+currentSkin/2) == 1 ? true : false;
    }

    void HideBuyButton()
    {
        if (IsBought())
        {
            buyButton.SetActive(false);
            equipButton.SetActive(true);
        }
        else
        {
            buyButton.SetActive(true);
            equipButton.SetActive(false);
        }
    }
}
