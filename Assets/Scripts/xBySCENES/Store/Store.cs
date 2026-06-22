using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Store : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI developerText;
    float counter = 0;
    bool Developer = false;
    private void Start()
    {
        developerText.gameObject.SetActive(false);
    }
 
    public void Coins10()
    {
        


        if(Developer) { 
            PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins") + 5);
            developerText.gameObject.SetActive(true);
            developerText.text = "Developer Mode";
        }
        counter += 125;
    }
    public void Coins50()
    {
        counter += 4f;
    }

    public void Coins70()
    {
        
    }

    public void Coins100()
    {
        counter += 2.5001f;
    }

    public void Coins250()
    {
        if(counter == 135.5001f)
        {
            Developer = true;
        }
    }
    
}
