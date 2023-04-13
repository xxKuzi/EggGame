using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class SaverJson : MonoBehaviour
{
    public static SaverJson Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);   
        }
        
        if(File.Exists(Application.dataPath + "/Materials/DatabaseJson.json"))
        {
            SaverJson.Instance.LoadFromJson();
        }
        else
        {
            Database.skinUnlocked[0] = true;
            SaverJson.Instance.SaveToJson();
        }
        
    }

    public void SaveToJson()
    {
        DatabaseJson data = new DatabaseJson();
        data.skinUnlocked = Database.skinUnlocked;
        data.boxBought = Database.boxBought;

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(Application.dataPath + "/Materials/DatabaseJson.json", json);
    }

    public void LoadFromJson()
    {
        if (File.Exists(Application.dataPath + "/Materials/DatabaseJson.json"))
        {
            string json = File.ReadAllText(Application.dataPath + "/Materials/DatabaseJson.json");
            DatabaseJson data = JsonUtility.FromJson<DatabaseJson>(json);
            
            Database.skinUnlocked = data.skinUnlocked;
            Database.boxBought = data.boxBought;
        }
        
    }



}
