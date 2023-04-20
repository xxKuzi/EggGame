using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardAfterAd : MonoBehaviour
{
   
    void Start()
    {
        
        if (PlayerPrefs.GetInt("InAd") == 3)
        {
            GoogleAdMobController.Instance.ShowInterstitialAd();
            PlayerPrefs.SetInt("InAd", 0);
        }
    }

   
    
    public void Coins(int coins)
    {
        PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins") + coins);
    }
}
