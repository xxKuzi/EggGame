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
        JoinGame();
        
        Sound();
        SceneManager.LoadScene("Game");        
    }
    public void GameMenu()
    {
        Sound();
        SceneManager.LoadScene("GameMenu");
    }    
    public void ExitGame()
    {
        Sound();
        LeaveGame();                
        SceneManager.LoadScene("GameMenu");        
    }
    
    public void ExitGameNoSoundAd()
    {
        LeaveGame();        
        PlayerPrefs.SetInt("InAd",PlayerPrefs.GetInt("InAd") + 1);
        SceneManager.LoadScene("GameMenu");

    }
      
    public void JoinGame()
    {
        SoundManager.Instance.Stop();
        SoundManager.Instance.PlayMusic("game");
    }
    public void LeaveGame()
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
