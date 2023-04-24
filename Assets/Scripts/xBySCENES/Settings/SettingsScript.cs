using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class SettingsScript : MonoBehaviour
{
    [SerializeField] GameObject fpsButton;
    [SerializeField] TextMeshProUGUI fpsButtonText;

    [SerializeField] GameObject musicButton;
    [SerializeField] TextMeshProUGUI musicsButtonText;
    [SerializeField] GameObject effectsButton;
    [SerializeField] TextMeshProUGUI effectsButtonText;

    SoundManager soundManager;
    int fpsIndex;
    int musicIndex;
    int effectsIndex;
    Image fpsButtonColor;
    Image musicButtonColor;
    Image effectsButtonColor;

    private void Start()
    {
        soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
        fpsButtonColor = fpsButton.GetComponent<Image>();
        musicButtonColor = musicButton.GetComponent<Image>();
        effectsButtonColor = effectsButton.GetComponent<Image>();

        if (PlayerPrefs.GetString("Fps") == "true")
        {
            FpsTrue();            

        }
        else
        {
            FpsFalse();           
        }

        if (PlayerPrefs.GetString("Music") == "false")
        {
            MusicFalse();
            

        }
        else
        {
            MusicTrue();
        }

        if (PlayerPrefs.GetString("Effects") == "false")
        {

            EffectsFalse();
        }
        else
        {
            EffectsTrue();
            
        }
    }

    //BUTTONS
    public void FpsButtonClick()
    {
        Sound();
        switch (fpsIndex)
        {
            case 0:               
                FpsTrue();
                break;
            case 1:
                FpsFalse();
                break;
        }

    }
    public void MusicButtonClick()
    {
        Sound();
        switch (musicIndex)
        {
            case 0:
                MusicTrue();                
                break;
            case 1:
                MusicFalse();                
                break;
        }

        
    }
    public void EffectsButtonClick()
    {
        
        switch (effectsIndex)
        {
            case 0:
                EffectsTrue();
                Sound();
                break;
            case 1:
                Sound();
                EffectsFalse();                
                break;
        }


    }

    //VOIDS
    void FpsTrue()
    {
        
        fpsButtonText.text = "ON";
        fpsButtonColor.color = Color.green;        
        PlayerPrefs.SetString("Fps", "true");
        fpsIndex = 1;
        
    }
    void FpsFalse()
    {
        fpsButtonText.text = "OFF";
        fpsButtonColor.color = Color.red;        
        PlayerPrefs.SetString("Fps", "false");
        fpsIndex = 0;
    }
    void MusicTrue()
    {
        
        musicsButtonText.text = "ON";
        musicButtonColor.color = Color.green;
        PlayerPrefs.SetString("Music", "true");
        musicIndex = 1;
        if(soundManager.menuSource.isPlaying == false)
        {
            soundManager.PlayMusic("menu");
        }
        
        
        
    }
    void MusicFalse()
    {
        soundManager.Stop();
        musicsButtonText.text = "OFF";
        musicButtonColor.color = Color.red;
        PlayerPrefs.SetString("Music", "false");
        musicIndex = 0;
    }
    void EffectsTrue()
    {
        effectsButtonText.text = "ON";
        effectsButtonColor.color = Color.green;
        PlayerPrefs.SetString("Effects", "true");
        effectsIndex = 1;
    }
    void EffectsFalse()
    {
        effectsButtonText.text = "OFF";
        effectsButtonColor.color = Color.red;
        PlayerPrefs.SetString("Effects", "false");
        effectsIndex = 0;
    }
    void Sound() //Button Sound
    {
        //SoundManager.Instance.Play("button");
    }
}
