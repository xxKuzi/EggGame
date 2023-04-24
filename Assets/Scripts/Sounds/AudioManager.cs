using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public static AudioManager Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        
        foreach (Sound s in sounds )
        {
            s.source = gameObject.AddComponent<AudioSource>();

            s.source.clip = s.clip;
            
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }

        AwakeMusicPlay();
    }

    public void AwakeMusicPlay()
    {
        if (PlayerPrefs.GetString("Music") == "true")
        {
            if (SceneManager.GetActiveScene().name == "Game")
            {
                Play("GameMusic");
            }
            else
            {
                Play("MenuMusic");
            }    
        }
        
    }
    public void Play(string soundName)
    {
        Sound s = Array.Find(sounds, x => x.name == soundName);
        if (s.source == null)
        {
            Debug.Log("Sound " + soundName + " was not found");
            return;
        }
        
        s.source.Play();
    }
    
    public void Stop(string soundName)
    {
        Sound s = Array.Find(sounds, x => x.name == soundName);
        if (s.source == null)
        {
            Debug.Log("Sound " + soundName + " was not found");
            return;
        }
        
        s.source.Stop();
    }
}
