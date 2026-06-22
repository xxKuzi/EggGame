using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AdButtonScript : MonoBehaviour
{
    
    

    private void Awake()
    {
        gameObject.GetComponent<Image>().enabled = false; 
        
        gameObject.GetComponent<Button>().onClick.AddListener(RewardedButtonClick);
        
    }

    void RewardedButtonClick()
    {
        GoogleAdMobController.Instance.ShowRewardedAd();
    }
    

    
}
