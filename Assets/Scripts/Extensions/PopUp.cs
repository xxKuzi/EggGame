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

    [SerializeField] Canvas popUpCanvas;
    [SerializeField] Image image;
    [SerializeField] private ReviewScript reviewscript;
    string gIndex;
    

    private void Start()
    {
        CloseAtStart();
    }
    public void CloseAtStart()
    {
        popUpCanvas.gameObject.SetActive(false);
        CloseWindow();
    }
    
    public void Sure(string index)
    {
        ActiveCanvas();
        if (index == "brown")
        {
            message.text = "Are you sure you want to buy " + index + " skin";
            gIndex = "brown";
        }
        if (index == "colored")
        {
            message.text = "Are you sure you want to buy " + index + " skin";
            gIndex = "colored";
        }

        image.gameObject.SetActive(true);
        headline.text = "Confirmation";        
        confirmButton.SetActive(true);
        confirmText.text = "Yes";
        declineButton.SetActive(true);
        declineText.text = "No";
        okButton.SetActive(true);
        okText.text = "cancel";
        //gIndex = "sure";
        



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
    public void ColorEquip(string color)
    {
        ActiveCanvas();
        headline.text = "Color changed succesfully";
        message.text = "Color changed to " + color;
        okButton.SetActive(true);
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
        image.gameObject.SetActive(true);
        gIndex = "newSkinUnlocked";
        message.text = "new Skin Unlocked";
        headline.text = "New Skin";
        okButton.SetActive(true);
        okText.text = "ok";
    }

    private void ActiveCanvas()
    {
        popUpCanvas.gameObject.SetActive(true);
    }
    
    
    //BUTTONs
    public void ConfirmButton()
    {
        CloseWindow();
        if(gIndex == "brown")
        {
            CodeNull();
            //shopButton.BuyBrown();
        }
        if(gIndex == "colored")
        {
            CodeNull();
            //shopButton.BuyColored();
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
        if(gIndex == "lowMoneyGame")
        {
            CodeNull();
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
        popUpCanvas.gameObject.SetActive(false);
        image.gameObject.SetActive(false);
    }
    void CodeNull()
    {
        gIndex = null;
    }



}
