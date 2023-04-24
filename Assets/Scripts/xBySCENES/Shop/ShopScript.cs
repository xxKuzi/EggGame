using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ShopScript : MonoBehaviour
{
    
    [SerializeField] private List<int> prices = new List<int>();
    [SerializeField] private List<Button> buttons = new List<Button>();
    [SerializeField] private List<TextMeshProUGUI> buttonsText = new List<TextMeshProUGUI>();

    [SerializeField] private List<bool> boxBought = new List<bool>();
    [SerializeField] private List<int> skinNumber = new List<int>();

    

    private void Start()
    {
        RefreshShop();
    }


    void RefreshShop()
    {
        
        boxBought = Database.boxBought;
        for (int i = 0; i < boxBought.Count; i++)
        {
            if (boxBought[i])
            {
                buttons[i].interactable = false;
                buttonsText[i].text = "Bought";    
            }
            
        }
        
    }

    public void BuySkin(int boxNumber)
    {
        if (PlayerPrefs.GetInt("coins") > prices[boxNumber]) //write it reversely

        {
            ButtonSound();
            PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins") - prices[boxNumber]);
            
            UnlockSkin(skinNumber[boxNumber]);
            Database.boxBought[boxNumber] = true;
            
            
            RefreshShop();

            SaverJson.Instance.SaveToJson();


        }
    }

    public void BuyCoins(int boxNumber, int coinsNumber)
    {
        
    }
    
    
    
    
    public void UnlockSkin(int number)
    {
        Database.skinUnlocked[number] = true;
        SaverJson.Instance.SaveToJson();
        PlayerPrefs.SetInt("skin", number);
    }
    
    


    //(PlayerPrefs.GetInt("coins")

    void ButtonSound()
    {
        AudioManager.Instance.Play("Button");
    }

    
}
