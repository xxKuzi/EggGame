using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopButton : MonoBehaviour
{
    [SerializeField] Transform buyBrown;
    [SerializeField] Transform buyColored;
    [SerializeField] TextMeshProUGUI buyBrownText;
    [SerializeField] TextMeshProUGUI buyColoredText;

    [SerializeField] Transform whiteButton;
    Image whiteB;
    [SerializeField] Transform brownButton;
    Image brownB;
    [SerializeField] Transform coloredButton;
    Image coloredB;

    int priceBrown = 5;
    int priceColored = 100;
    public PopUp popUp;


    [SerializeField] TextMeshProUGUI whiteText;
    [SerializeField] TextMeshProUGUI brownText;
    [SerializeField] TextMeshProUGUI coloredText;

    [SerializeField] GameObject whiteEgg;
    [SerializeField] GameObject brownEgg;
    [SerializeField] GameObject coloredEgg;

    private void Start()
    {        
        whiteB = whiteButton.GetComponent<Image>();
        brownB = brownButton.GetComponent<Image>();
        coloredB = coloredButton.GetComponent<Image>();        
        buyBrownText.text = "Buy " + priceBrown + " coins";
        buyColoredText.text = "Buy " + priceColored + " coins";
        if (PlayerPrefs.GetString("brownLock") == "unlock")
        {
            buyBrown.gameObject.SetActive(false);

        }
        if (PlayerPrefs.GetString("coloredLock") == "unlock")
        {
            buyColored.gameObject.SetActive(false);
        }
        switch(PlayerPrefs.GetString("color"))
        {
            case "white":
                WhiteButton();
                break;

            case "brown":
                BrownButton();
                break;
            case "colored":
                ColoredButton();
                break;
            
        }



    }
    
    public void WhiteButton()
    {
        EquipSound();
        PlayerPrefs.SetString("color", "white");

        whiteB.color = Color.green;
        brownB.color = Color.white;
        coloredB.color = Color.white;

        whiteText.text = "Equipped";
        brownText.text = "Equip";
        coloredText.text = "Equip";

        whiteEgg.SetActive(true);
        coloredEgg.SetActive(false);
        brownEgg.SetActive(false);


    }
    public void BrownButton()
    {
        EquipSound();
        PlayerPrefs.SetString("color", "brown");

        whiteB.color = Color.white;
        brownB.color = Color.green;
        coloredB.color = Color.white;

        brownText.text = "Equipped";
        whiteText.text = "Equip";
        coloredText.text = "Equip";

        brownEgg.SetActive(true);
        whiteEgg.SetActive(false);
        coloredEgg.SetActive(false);


    }
    public void ColoredButton()
    {
        EquipSound();
        PlayerPrefs.SetString("color", "colored");

        coloredB.color = Color.green;
        whiteB.color = Color.white;
        brownB.color = Color.white;

        coloredText.text = "Equipped";
        whiteText.text = "Equip";
        brownText.text = "Equip";

        coloredEgg.SetActive(true);
        brownEgg.SetActive(false);
        whiteEgg.SetActive(false);

        //popUp.ColorEquip("colored");
    }
    public void BuyBrownButton()
    {
        ButtonSound();
        if (PlayerPrefs.GetInt("coins") >= priceBrown)
        {
            popUp.Sure("brown");
        }
        else
        {
            popUp.LowMoney();
        }
        
    }
    public void BuyBrown()
    {
        BuySound();
        PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins") - priceBrown);
        PlayerPrefs.SetString("color", "brown");
        PlayerPrefs.SetString("brownLock", "unlock");
        buyBrown.gameObject.SetActive(false);        
    }
    public void BuyColoredButton()
    {
        ButtonSound();
        if (PlayerPrefs.GetInt("coins") >= priceColored)
        {
            popUp.Sure("colored");
        }
        else
        {
            popUp.LowMoney();
        }
        
    }
    public void BuyColored()
    {
        BuySound();
        PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins") - priceColored);
        PlayerPrefs.SetString("color", "colored");
        PlayerPrefs.SetString("coloredLock", "unlock");
        buyColored.gameObject.SetActive(false);
    }
    void BuySound()
    {
        SoundManager.Instance.Play("buy");
    }
    void ButtonSound()
    {
        SoundManager.Instance.Play("button");
    }
    void EquipSound()
    {
        SoundManager.Instance.Play("equip");
    }
}
