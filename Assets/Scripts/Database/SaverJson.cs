using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class SaverJson : MonoBehaviour
{
    public static SaverJson Instance;
    public static string directory = "/PlayerData/";
    public static string fileName = "GameData.txt";

    
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
        Debug.Log(Application.persistentDataPath);
        string dir = Application.persistentDataPath + directory;
        if(File.Exists(dir + fileName))
        {
            SaverJson.Instance.LoadFromJson();
        }
        else
        {
            Debug.Log("Saving new file");
            
     
            Directory.CreateDirectory(dir);
            Database.skinUnlocked[0] = true;
            SaverJson.Instance.SaveToJson();
        }
        
    }

    public void SaveToJson()
    {
        string dir = Application.persistentDataPath + directory;
        DatabaseJson data = new DatabaseJson();
        data.skinUnlocked = Database.skinUnlocked;
        data.boxBought = Database.boxBought;

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(dir + fileName, json);
    }

    public void LoadFromJson()
    {
        string dir = Application.persistentDataPath + directory;
        if (File.Exists(dir + fileName))
        {
            string json = File.ReadAllText(dir + fileName);
            DatabaseJson data = JsonUtility.FromJson<DatabaseJson>(json);
            
            Database.skinUnlocked = data.skinUnlocked;
            Database.boxBought = data.boxBought;
        }
        
    }



}
