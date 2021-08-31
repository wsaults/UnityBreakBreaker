using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public string PlayerName;
    public string HighScorePlayerName;
    public int HighScore;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadLastPlayer();
        LoadHighScore();
    }

    [System.Serializable]
    class SavePlayerData
    {
        public string LastPlayerName;
    }

    public void SaveLastPlayer()
    {
        SavePlayerData data = new SavePlayerData();
        data.LastPlayerName = PlayerName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/playersavefile.json", json);
    }

    public void LoadLastPlayer()
    {
        string path = Application.persistentDataPath + "/playersavefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SavePlayerData data = JsonUtility.FromJson<SavePlayerData>(json);

            PlayerName = data.LastPlayerName;
        }
    }

    [System.Serializable]
    class SaveHighScoreData
    {
        public string LastPlayerName;
        public string HighScorePlayerName;
        public int HighScore;
    }

    public void SaveHighScore()
    {
        SaveHighScoreData data = new SaveHighScoreData();
        data.HighScorePlayerName = HighScorePlayerName;
        data.HighScore = HighScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/scoresavefile.json", json);
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/scoresavefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveHighScoreData data = JsonUtility.FromJson<SaveHighScoreData>(json);

            HighScorePlayerName = data.HighScorePlayerName;
            HighScore = data.HighScore;
        }
    }
}
