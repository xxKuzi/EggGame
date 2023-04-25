using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using JetBrains.Annotations;
using Unity.VisualScripting;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class SkinList : MonoBehaviour
{
    //private Database database = Database.Instance;
    [SerializeField] private SkinSelect skinselect;
    [SerializeField] private SkinMenu skinMenu;
    [CanBeNull] public List<Sprite> allSkins = new List <Sprite>();
    public List<bool> unlockedSkins = new List<bool>();
    [SerializeField] public List<int> indexInUnlockedSkins = new List<int>();
    private int numberOfCycle;
    
    
    [HideInInspector] public int noSkins;

   

    private void Start()
    {
        RefreshSkins();
    }

    public void RefreshSkins()
    {
        unlockedSkins = Database.skinUnlocked;
        noSkins = allSkins.Count;
        
        
        //CLEARING SKIN SELECT LIST (BECAUSE IT HAS TO BE DONE WHEN WE REFRESHING SKINS)
        skinselect.skins.Clear();
        //CLEARING NUMBER OF CYCLES (BECAUSE IT HAS TO BE DONE WHEN WE REFRESHING SKINS)
        numberOfCycle = 0; 
        
        
        
        //ADDING SKINS TO SKIN SELECT + INDEXING THEM
        for (int i = 0; i < noSkins; i++)
        {
            if (unlockedSkins[i] == true)
            {
                skinselect.skins.Add(allSkins[i]);
                
                indexInUnlockedSkins[i] = numberOfCycle;
                numberOfCycle++; //every cycle equals one index in UnlockedSkins 

            }
            
        }
        
        
        skinMenu.LockedSkins();
        skinselect.UpdateSkin();
    }
}
