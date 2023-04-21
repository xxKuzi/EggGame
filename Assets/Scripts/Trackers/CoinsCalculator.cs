using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoinsCalculator : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI coinsText;

   


    void Update()
    {
        coinsText.text = "" + PlayerPrefs.GetInt("coins"); 
    }
}
