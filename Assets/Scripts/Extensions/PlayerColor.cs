using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerColor : MonoBehaviour
{

    
    
    private int skinNumber;

    [SerializeField] GameObject whiteEgg;
    [SerializeField] GameObject brownEgg;
    [SerializeField] GameObject coloredEgg;
    
    //0 White
    //1 Brown
    //2 Colored

    private void Start()
    {
        skinNumber = PlayerPrefs.GetInt("skin");

        if (skinNumber == 0)
        {
            whiteEgg.SetActive(true);
            coloredEgg.SetActive(false);
            brownEgg.SetActive(false);
        }

        if (skinNumber == 1)
        {
            brownEgg.SetActive(true);
            whiteEgg.SetActive(false);
            coloredEgg.SetActive(false);
            
        }
        if (skinNumber == 2)
        {
            coloredEgg.SetActive(true);
            brownEgg.SetActive(false);
            whiteEgg.SetActive(false);

        }
    }
    


 
}
