using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowScaler : MonoBehaviour
{
    [SerializeField] private GameObject window;
    private int cellHeight = 42;
    
    private void Awake()
    {
        PlayerPrefs.SetInt("coins", 10);
        window.GetComponent<RectTransform>().sizeDelta = new Vector2(73, cellHeight);
        if (PlayerPrefs.GetInt("coins") > 9)
        {
            window.GetComponent<RectTransform>().sizeDelta = new Vector2(97, cellHeight);
            if (PlayerPrefs.GetInt("coins") > 99)
            {
                window.GetComponent<RectTransform>().sizeDelta = new Vector2(118, cellHeight);
                if (PlayerPrefs.GetInt("coins") > 999)
                {
                    window.GetComponent<RectTransform>().sizeDelta = new Vector2(141, cellHeight);
                }
            }
            
        }
    }
}
