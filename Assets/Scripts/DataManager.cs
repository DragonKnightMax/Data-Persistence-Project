using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public string CurrentPlayerName;
    public string BestPlayerName;
    public int BestScore;
    private string saveFile = "savefile.json";

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadBestScore();
    }

    public void CheckBestScore(int currentScore)
    {
        if (currentScore > BestScore)
        {
            DataManager.Instance.BestPlayerName = CurrentPlayerName;
            DataManager.Instance.BestScore = currentScore;
            DataManager.Instance.SaveBestScore();
        }
    }

    // data persistence between sessions
    [System.Serializable]
    class SaveData
    {
        public string PlayerName;
        public int Score;
    }
    public void SaveBestScore()
    {
        SaveData saveData = new SaveData();
        saveData.PlayerName = BestPlayerName;
        saveData.Score = BestScore;

        string json = JsonUtility.ToJson(saveData);

        string savePath = $"{Application.persistentDataPath}/{saveFile}";
        File.WriteAllText(savePath, json);
    }

    public void LoadBestScore()
    {
        string savePath = $"{Application.persistentDataPath}/{saveFile}";
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            SaveData saveData = JsonUtility.FromJson<SaveData>(json);

            BestPlayerName = saveData.PlayerName;
            BestScore = saveData.Score;
        }
        
    }
}
