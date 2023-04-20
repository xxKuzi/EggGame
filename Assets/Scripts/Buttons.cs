using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class Buttons : MonoBehaviour
{
    
    private void Start()
    {
        //PlayerPrefs.DeleteAll();
    }
    public void Shop()
    {
        Sound();
        SceneManager.LoadScene("Shop");
    }
    public void Play()
    {
        JoinGameMusic();
        
        Sound();
        SceneManager.LoadScene("Game");        
    } 
    //GAME MENU
    public void GameMenu()
    {
        Sound();
        LoadGameMenu();
       
    }    
    public void ExitGame()
    {
        Sound();
        LeaveGameMusic();                
        LoadGameMenu();       
    }
    
    public void ExitGameNoSoundAd()
    {
        LeaveGameMusic();        
        PlayerPrefs.SetInt("InAd",PlayerPrefs.GetInt("InAd") + 1);
        LoadGameMenu();

    }

    void LoadGameMenu()
    {
        SceneManager.LoadScene("GameMenu");
        
    }
//GAME MENU
    public void JoinGameMusic()
    {
        SoundManager.Instance.Stop();
        SoundManager.Instance.PlayMusic("game");
    }
    public void LeaveGameMusic()
    {
        SoundManager.Instance.Stop();
        SoundManager.Instance.PlayMusic("menu");
    }
    public void Settings()
    {
        Sound();
        SceneManager.LoadScene("Settings");
    }
    public void Store()
    {       
        Sound();
        SceneManager.LoadScene("Store");        
    }    
    void Sound()
    {
        SoundManager.Instance.Play("button");
    }    


    
    
}
