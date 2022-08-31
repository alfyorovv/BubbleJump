using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    bool soundEnabled;
    public Sprite sprite1, sprite2;
    public Button soundButton;

    public void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        if (AudioListener.volume == 1)
            soundEnabled = true;
        else
            soundEnabled = false;

        if (soundEnabled)
        {
            soundButton.image.sprite = sprite1;
        }
        else
        {
            soundButton.image.sprite = sprite2;
        }
    }

    public void SwitchSound()
    {
        if (soundEnabled)
        {
            AudioListener.volume = 0;
            soundEnabled = !soundEnabled;
            soundButton.image.sprite = sprite2;
        }
        else
        {
            AudioListener.volume = 1f;
            soundEnabled = !soundEnabled;
            soundButton.image.sprite = sprite1;
        }
    }
}
