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
        Invoke("AfterStart",0.1f);
    }

    void AfterStart()
    {
        if (SceneManager.GetActiveScene().name == "GameMenu")
        {
            
                
            GoogleAdMobController.Instance.RequestBannerAd();    
            
        
            if (PlayerPrefs.GetInt("InAd") == 3)
            {
                GoogleAdMobController.Instance.ShowInterstitialAd();
                PlayerPrefs.SetInt("InAd", 0);
            }
            
        }
        else
        {
            Debug.Log("NOT GAMEMENu");
            GoogleAdMobController.Instance.DestroyBannerAd();
            GoogleAdMobController.Instance.HideBannerAd();
        }

    }
    
    public void Coins(int coins)
    {
        PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins") + coins);
    }
}
