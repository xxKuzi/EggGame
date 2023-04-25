using System;
using System.Collections;
using System.Collections.Generic;
using GoogleMobileAds.Api;
using UnityEngine;

public class ReviewScript : MonoBehaviour
{
    [SerializeField] private PopUp popUp;
    [SerializeField] private SkinList skinList;
    

    private void Start()
    {
        TryIfUsed();
    }

    void TryIfUsed()
    {
        if (PlayerPrefs.GetString("starSkin") == "true")
        {
            gameObject.SetActive(false);
        }

    }
    public void StarClicked()
    {
        popUp.Review();
    }

    public void GoPage()
    {
        Application.OpenURL ("https://play.google.com/store/apps/details?id=com.juicyy.jumpgame");
        GetReward();
    }
    public void GetReward()
    {
        
        
            Database.skinUnlocked[3] = true;
            SaverJson.Instance.SaveToJson();

            
            PlayerPrefs.SetInt("skin", 3);
            skinList.RefreshSkins();
            
            Invoke("RewardWindow", 3f);
            
            
            //We need to show that start only once
            PlayerPrefs.SetString("starSkin", "true");
            TryIfUsed();
            
    }

    void RewardWindow()
    {
        popUp.NewSkinUnlocked(3);
    }

    
}
