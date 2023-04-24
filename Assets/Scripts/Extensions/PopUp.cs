using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PopUp : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Headline;
    [SerializeField] private TextMeshProUGUI Message;
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
    [SerializeField] Image newSkinImage;
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
        popUpCanvas.gameObject.SetActive(true);
        if (index == "brown")
        {
            Message.text = "Are you sure you want to buy " + index + " skin";
            gIndex = "brown";
        }
        if (index == "colored")
        {
            Message.text = "Are you sure you want to buy " + index + " skin";
            gIndex = "colored";
        }

        newSkinImage.gameObject.SetActive(true);
        Headline.text = "Confirmation";        
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
        popUpCanvas.gameObject.SetActive(true);
        Headline.text = "Not enough Money";
        Message.text = "You do not have enought money";
        okButton.SetActive(true);
        okText.text = "OK";
        alternativeButton.SetActive(true);
        alternativeText.text = "Buy coins";
        gIndex = "lowMoney";
        
        
    }
    public void LowMoneyGame()
    {
        popUpCanvas.gameObject.SetActive(true);
        Headline.text = "Not enough Money";
        Message.text = "You do not have enought money";
        okButton.SetActive(true);
        okText.text = "OK";
        alternativeButton.SetActive(true);
        alternativeText.text = "Buy coins";
        gIndex = "lowMoneyGame";


    }
    public void ColorEquip(string color)
    {
        popUpCanvas.gameObject.SetActive(true);
        Headline.text = "Color changed succesfully";
        Message.text = "Color changed to " + color;
        okButton.SetActive(true);
    }    

    //BUTTONs
    public void ConfirmButton()
    {
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
        CloseWindow();
    }

    public void Review()
    {
        popUpCanvas.gameObject.SetActive(true);
        gIndex = "review";
        confirmButton.SetActive(true);
        confirmText.text = "Get Skin";
        okButton.SetActive(true);
        okText.text = "cancel";
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
        //newSkinImage.gameObject.SetActive(false);
    }
    void CodeNull()
    {
        gIndex = null;
    }



}
