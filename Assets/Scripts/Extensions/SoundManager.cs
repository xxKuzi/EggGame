using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    [SerializeField] public AudioSource effectsSource, gameSource, menuSource, coinSource;    
    [SerializeField] public AudioClip button; // MAYBE WITHOUT PUBLIC 
    [SerializeField] public AudioClip jump;
    [SerializeField] public AudioClip death;    
    [SerializeField] public AudioClip coin;
    [SerializeField] public AudioClip dia;
    //[SerializeField] public AudioClip
    //[SerializeField] public AudioClip
        
    [SerializeField] public AudioClip trampoline;
    [SerializeField] public AudioClip magnet;
    [SerializeField] public AudioClip shoes;
    [SerializeField] public AudioClip buy;
    [SerializeField] public AudioClip equip;

    [SerializeField] public AudioClip menu;
    [SerializeField] public AudioClip game;
    
    private void Awake()
    {        
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            
        }    
        else {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        

    }
    private void Start()
    {
        if(PlayerPrefs.GetString("Music") == "")
        {
            PlayerPrefs.SetString("Music", "true");
        }
        if(PlayerPrefs.GetString("Effects") == "")
        {
            PlayerPrefs.SetString("Effects", "true");
        }


        if (PlayerPrefs.GetString("Music") == "true")
        {            
            if (SceneManager.GetActiveScene().name != "Game" && menuSource.isPlaying == false)
            {
                menuSource.PlayOneShot(menu);
            }
        }
        
    }
    




    public void Stop()
    {       
        menuSource.Stop();
        gameSource.Stop();                        
    }

    public void Play(AudioClip sound)
    {
        
        if (PlayerPrefs.GetString("Effects") == "true")
        {
            if (sound == coin)
            {
                coinSource.PlayOneShot(coin);
            }
            else
            {
                effectsSource.PlayOneShot(sound);    
            }
            // make volume changing here in script instead of two sources(effectSource, coinSource)
            
        }
        
    }
    public void PlayMusic(string sound)
    {
        if (PlayerPrefs.GetString("Music") == "true")
        {
            switch (sound)
            {
                case "menu":
                    menuSource.PlayOneShot(menu);
                    break;
                case "game":
                    gameSource.PlayOneShot(game);
                    break;
            }
        }
        
    }
   

    




}