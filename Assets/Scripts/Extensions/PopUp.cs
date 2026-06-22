using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PopUp : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI headline;
    [SerializeField] private TextMeshProUGUI message;
    [SerializeField] Buttons buttonsScript;

    [SerializeField] GameObject confirmButton;
    [SerializeField] TextMeshProUGUI confirmText;
    [SerializeField] GameObject declineButton;
    [SerializeField] TextMeshProUGUI declineText;
    [SerializeField] GameObject okButton;
    [SerializeField] TextMeshProUGUI okText;
    [SerializeField] GameObject alternativeButton;
    [SerializeField] TextMeshProUGUI alternativeText;
    
    [SerializeField] Image image;
    [SerializeField] private ReviewScript reviewscript;
    [SerializeField] private ShopScript shopScript;
    private int skinNumber;
    string gIndex;
    private int boxNumber;
    

    private void Start()
    {
        CloseAtStart();
    }
    public void CloseAtStart()
    {
        gameObject.SetActive(false);
        CloseWindow();
    }
    
    
    
    // public void Sure(string index)
    // {
    //     ActiveCanvas();
    //     
    //     message.text = "Are you sure you want to buy " + index + " skin";
    //
    //     gIndex = "Buy" + index;
    //     
    //     
    //
    //     image.gameObject.SetActive(true);
    //     headline.text = "Confirmation";        
    //     confirmButton.SetActive(true);
    //     confirmText.text = "Yes";
    //     declineButton.SetActive(true);
    //     declineText.text = "No";
    //     okButton.SetActive(true);
    //     okText.text = "cancel";
    //     //gIndex = "sure";
    //     
    //
    //
    //
    // }
    
    public void BuySkinBox(int boxNumber2)
    {
        
        ActiveCanvas();
        boxNumber = boxNumber2;
        skinNumber = shopScript.skinNumber[boxNumber];
        string skinName = SkinNames.skin[skinNumber];
        
        message.text = "Are you sure you want to buy " + skinName + " skin?";


        
        
        
        

        image.gameObject.SetActive(true);
        headline.text = "Confirmation";        
        confirmButton.SetActive(true);
        confirmText.text = "Yes";
        declineButton.SetActive(true);
        declineText.text = "No";
        
        gIndex = "buySkin";
        



    }
    public void LowMoney()
    {
        ActiveCanvas();
        headline.text = "Not enough Money";
        message.text = "You do not have enought money";
        okButton.SetActive(true);
        okText.text = "OK";
        alternativeButton.SetActive(true);
        alternativeText.text = "Buy coins";
        gIndex = "lowMoney";
        
        
    }
    public void LowMoneyGame()
    {
        ActiveCanvas();
        headline.text = "Not enough Money";
        message.text = "You do not have enought money";
        okButton.SetActive(true);
        okText.text = "OK";
        alternativeButton.SetActive(true);
        alternativeText.text = "Buy coins";
        gIndex = "lowMoneyGame";


    }
      

    public void Review()
    {
        ActiveCanvas();
        gIndex = "review";
        headline.text = "Skin for Review";
        message.text = "Review Egg Game on Play Store and get FREE SKIN";
        confirmButton.SetActive(true);
        confirmText.text = "Get Skin";
        okButton.SetActive(true);
        okText.text = "cancel";
    }
    
    public void NewSkinUnlocked(int numberOfSkin)
    {
        ActiveCanvas();
        AudioManager.Instance.Play("NewSkin");
        image.gameObject.SetActive(true);
        gIndex = "newSkinUnlocked";
        message.text = "new Skin Unlocked";
        headline.text = "New Skin";
        okButton.SetActive(true);
        okText.text = "ok";
    }

    private void ActiveCanvas()
    {
        gameObject.SetActive(true);
    }
    
    
    //BUTTONs
    public void ConfirmButton()
    {
        
        CloseWindow();
        if(gIndex == "buySkin")
        {
            shopScript.BuySkin(boxNumber);
        }
        

        if (gIndex == "review")
        {
            reviewscript.GoPage();
        }
        
        
    }

    

    public void DeclineButton()
    {
        CloseWindow();
 
    }
    public void OKButton()
    {
        if (gIndex == "lowMoneyGame")
        {
            CodeNull();
            buttonsScript.LeaveGameMusic();
            SceneManager.LoadScene("GameMenu");

            
        }
        else
        {
            CloseWindow();
        }
        

    }
    public void AlternativeButton()
    {
        if (gIndex == "lowMoney")
        {
            SceneManager.LoadScene("Store");
        }
        if(gIndex == "lowMoneyGame")
        {
            
            buttonsScript.LeaveGameMusic();
            SceneManager.LoadScene("Store");

            
        }
        else
        {
            SceneManager.LoadScene("Store");
        }
        
    }



    //VOIDs
    void CloseWindow()
    {
        confirmButton.SetActive(false);
        declineButton.SetActive(false);
        alternativeButton.SetActive(false);
        okButton.SetActive(false);
        gameObject.SetActive(false);
        image.gameObject.SetActive(false);
    }
    void CodeNull()
    {
        gIndex = null;
    }



}
