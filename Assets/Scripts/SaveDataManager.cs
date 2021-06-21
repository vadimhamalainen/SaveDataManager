using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveDataManager : MonoBehaviour
{
    public static SaveDataManager instance;

    public string playerName;
    public int maxScore;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }

        instance = this;
        DontDestroyOnLoad(instance);
    }

   
    public static void SaveData()
    {
        string path = Application.persistentDataPath + "data.json";

        Data data = new Data() { playerName = instance.playerName, maxScore = instance.maxScore };

        string jsonText = JsonUtility.ToJson(data);

        File.WriteAllText(path, jsonText);
    }

    public static void LoadData()
    {
        string path = Application.persistentDataPath + "data.json";

        if(File.Exists(path))
        {
            string jsonText =  File.ReadAllText(path);
            Data data = JsonUtility.FromJson<Data>(jsonText);

            instance.playerName = data.playerName;
            instance.maxScore = data.maxScore;
        }
    }

    class Data
    {
        public string playerName;
        public int maxScore;
    }
}
