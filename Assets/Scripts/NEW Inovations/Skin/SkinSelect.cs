using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkinSelect : MonoBehaviour
{
    [SerializeField] private SkinList skinList;
    public List<Sprite> skins = new List<Sprite>();
    
    int selectedSkin = 0;
    [SerializeField] Image img;
    [SerializeField] private Image rightImg;
    [SerializeField] private Image leftImg;
    

    //0 White
    //1 Brown
    //2 Colored


   

    public void UpdateSkin()
    {
        selectedSkin = skinList.indexInUnlockedSkins[PlayerPrefs.GetInt("skin")]; // == INDEX of skin in UnlockedSkins List which EQUALS AllSkins List skin
        RefreshSkins();
        
    }

    

    public void saveValue()
    {
        PlayerPrefs.SetInt("skin", skinList.indexInUnlockedSkins.IndexOf(selectedSkin));
    }
    public void NextButton()
    {
        selectedSkin = selectedSkin - 1;

        if(selectedSkin < 0)
        {
            selectedSkin = skins.Count - 1;
        }
        saveValue();

        RefreshSkins();
        
            
    }
    public void BackButton()
    {
        selectedSkin = selectedSkin + 1;
        
        if(selectedSkin == skins.Count)
        {
            selectedSkin = 0;
        }
        saveValue();

        RefreshSkins();
        
        
    }

    void RefreshSkins()
    {
        img.sprite = skins[selectedSkin];
        
        //Right
        if (selectedSkin == skins.Count - 1)
        {
            rightImg.sprite = skins[0];
        }
        else
        {
            rightImg.sprite = skins[selectedSkin + 1]; 
        }
           
        
        
        //Left
        if (selectedSkin == 0)
        {
            leftImg.sprite = skins[skins.Count - 1];
        }
        else
        {
            leftImg.sprite = skins[selectedSkin - 1];   
        }
    }

    
}
