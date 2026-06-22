using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FPS : MonoBehaviour
{
    int frames;
    float time;
    [SerializeField] TextMeshProUGUI fpsCounter;


    private void Awake()
    {
        
        if (PlayerPrefs.GetString("Fps") == "true") { fpsCounter.gameObject.SetActive(true); }
        else { fpsCounter.gameObject.SetActive(false); }
        
    }

    void Update()
    {

        time += Time.deltaTime;
        frames++;

        

        if(time >= 1f)
        {
            
            fpsCounter.text = "Fps: " + (frames);


            ToNull();
        }

        
    }
    void ToNull()
    {
        time = 0;
        frames = 0;
    }
    
}

