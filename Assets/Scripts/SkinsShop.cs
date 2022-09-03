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
    public GameObject tapToChangeSkinText;
    public GameObject priceText;

    int currentSkin;
    SpriteRenderer sr;
    public Sprite[] skins;
    public int[] prices;

    private void Awake()
    {
        //PlayerPrefs.DeleteAll();
        currentSkin = PlayerPrefs.GetInt("currentSkin");
        sr = GameObject.Find("MainMenuPlayer").GetComponent<SpriteRenderer>();
        PlayerPrefs.SetInt("isBought0", 1); //First skin is always bought
    }

    private void Start()
    {
        SkinPreview();
        //priceText.SetActive(false);
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
        tapToChangeSkinText.SetActive(false);
        priceText.SetActive(true);

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
        equipButton.SetActive(false);
        tapToChangeSkinText.SetActive(true);
        priceText.SetActive(false);
        currentSkin = PlayerPrefs.GetInt("currentSkin");
        SkinPreview();
    }

    public void EquipButtonClicked()
    {
        equipButton.SetActive(false);
        PlayerPrefs.SetInt("currentSkin", currentSkin);
        SkinPreview();
    }

    public void NextSkinButtonClicked()
    {
        currentSkin+=2; //Player has 2 sprites, +2 to iterate every pair
        HideArrows();
        SkinPreview();
        HideBuyButton();
    }

    public void PrevSkinButtonClicked()
    {
        currentSkin-=2; //Player has 2 sprites, -2 to iterate every pair
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

        if (currentSkin == 2*skins.Length - 2) //currentSkin have step 2 and reaching end when equals 2 array's length - 2
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
        if(PlayerPrefs.GetInt("coins") >= prices[currentSkin/2])
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
        priceText.GetComponent<Text>().text = "x" + prices[currentSkin / 2];
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
