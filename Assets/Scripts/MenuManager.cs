using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System;
using UnityEngine.UI;


public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;
    public string bestScoreName, currentName;
    public int bestScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadScore();
    }

    [Serializable]
    class SaveData
    {
        public string bestScoreName;
        public int bestScore;
    }

    public void SaveScore(int points)
    {
        SaveData data = new SaveData();
        data.bestScoreName = currentName;
        data.bestScore = points;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestScoreName = data.bestScoreName;
            bestScore = data.bestScore;

        }
    }

   
}
