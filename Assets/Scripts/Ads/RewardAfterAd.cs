using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardAfterAd : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.SetInt("InAd", 0);
        if (PlayerPrefs.GetInt("InAd") == 3)
        {
            GoogleAdMobController.AdmobManager.RequestAndLoadInterstitialAdandLoad();
            PlayerPrefs.SetInt("InAd", 0);
        }
    }

    // Update is called once per frame
    
    public void Coins(int coins)
    {
        PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins") + coins);
    }
}
