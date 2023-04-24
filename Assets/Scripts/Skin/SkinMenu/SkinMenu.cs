using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using TMPro;
using Button = UnityEngine.UI.Button;


public class SkinMenu : MonoBehaviour
{
    [SerializeField] SkinMenuOpenClose openClose;
    [SerializeField] SkinList skinList;
    [SerializeField] public List<Button> buttonsList = new List<Button>();
    [SerializeField] public List<GameObject> lockList = new List<GameObject>();
    

    public void Select(int number)
    {
        Sound();
        PlayerPrefs.SetInt("skin", number);
        openClose.CloseMenuNoSound();
    }

    

    public void LockedSkins()
    {
        for (int i = 0; i < skinList.noSkins; i++)
        {
            lockList[i].SetActive(false);
        }
        
        
        
        for (int i = 0; i < skinList.noSkins; i++)
        {
            if (skinList.unlockedSkins[i] == false)
            {
                buttonsList[i].enabled = false;
                lockList[i].SetActive(true);
            }    
        }
        
           
    }

    void Sound()
    {
        AudioManager.Instance.Play("SkinEquip");
    }
}
