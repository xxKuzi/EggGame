using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReviewScript : MonoBehaviour
{
    [SerializeField] private PopUp popUp;

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
    }

    
}
