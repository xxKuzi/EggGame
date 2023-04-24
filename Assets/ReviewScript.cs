using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReviewScript : MonoBehaviour
{
    [SerializeField] private PopUp popUp;
    [SerializeField] private SkinList skinList;

    private void Start()
    {
        if (PlayerPrefs.GetString("starSkin") == "true")
        {
            gameObject.SetActive(false);
            Debug.Log("SET ACTIVE FALSE");
        }
        
    }

    public void StarClicked()
    {
        popUp.Review();
    }

    public void GoPage()
    {
        Application.OpenURL ("market://details?id=" + Application.productName);
        GetReward();
    }
    public void GetReward()
    {
        
        
            Database.skinUnlocked[3] = true;
            SaverJson.Instance.SaveToJson();
            PlayerPrefs.SetInt("skin", 3);
            skinList.RefreshSkins();
            popUp.NewSkinUnlocked(3);

            PlayerPrefs.SetString("starSkin", "true");
        
            
    }

    
}
