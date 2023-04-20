using System;
using System.Collections;
using System.Collections.Generic;
using GoogleMobileAds.Api;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RewardAfterAd : MonoBehaviour
{
    

    private void OnEnable()
    {
        Invoke("DelayerStart", 0.1f);
    }

    void DelayerStart()
    {
        
        if (GoogleAdMobController.Instance != null)
        {
            if (SceneManager.GetActiveScene().name == "GameMenu")
            {
                GoogleAdMobController.Instance.FindButton();
                GoogleAdMobController.Instance.RequestBannerAd();    
                if (PlayerPrefs.GetInt("InAd") >= 3)
                {
                    Debug.Log("INTERSITIAL AD");
                    GoogleAdMobController.Instance.ShowInterstitialAd();
                    PlayerPrefs.SetInt("InAd", 0);
                }
            
            }
            else
            {
                GoogleAdMobController.Instance.HideBannerAd();
            
                
            }   
        }
    }

   
    
    
}
