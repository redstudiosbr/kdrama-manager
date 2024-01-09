using UnityEngine;
using System.IO;

public class GameProgressManager : PersistentSingleton<GameProgressManager>
{
    [SerializeField] private GameProgressData _progressData;

    private string _saveFilePath;

    protected override void Awake()
    {
        base.Awake();
        _saveFilePath = Path.Combine(Application.persistentDataPath, "data.json");
        LoadGame();
    }

    public void SaveGame()
    {
        string json = JsonUtility.ToJson(_progressData);
        File.WriteAllText(_saveFilePath, json);
        Debug.Log("Game Saved");
    }

    public void LoadGame()
    {
        if (File.Exists(_saveFilePath))
        {
            string json = File.ReadAllText(_saveFilePath);
            _progressData = JsonUtility.FromJson<GameProgressData>(json);
            Debug.Log("Game Loaded");
        }
        else
        {
            _progressData = new GameProgressData();
            Debug.Log("No Save File Found, Created New Save Data");
        }
    }

    public void UpdatePlayerName(string name)
    {
        _progressData.PlayerName = name;
        SaveGame();
    }
}
