using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameSkin : MonoBehaviour
{
    public List<Sprite> allSkins = new List <Sprite>(new Sprite[10]);
    
    [SerializeField] SpriteRenderer eggImage;
    private int skinNumber;

    private void Awake()
    {
        skinNumber = PlayerPrefs.GetInt("skin");
        eggImage.sprite = allSkins[skinNumber];
    }
}
