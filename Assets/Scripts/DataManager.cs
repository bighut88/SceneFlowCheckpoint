using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance { get; private set; }
    public Player player { get; set; }

    public string currentPlayerName;

    public string path;

    public class Player
    {
        public string playerName;
        public int points;
    }

    void Start()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            path = Application.persistentDataPath + "/highScore.json";
            player = new Player();
            LoadData();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SaveData()
    {
        string json = JsonUtility.ToJson(player);

        File.WriteAllText(path, json);
    }

    public void LoadData()
    {
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);

            JsonUtility.FromJsonOverwrite(json, player);
        }
        else
        {
            player.playerName = "none";
            player.points = 0;
        }
    }

}
