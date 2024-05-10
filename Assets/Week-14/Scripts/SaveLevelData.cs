using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEditor;
using UnityEngine;

public class SaveLevelData : MonoBehaviour
{
    public string LevelName;
    public string LevelReward;
    public string EnemyNumber;

    [SerializeField] TextMeshProUGUI LevelNameField;
    [SerializeField] TextMeshProUGUI LevelRewardField;
    [SerializeField] TextMeshProUGUI EnemyNumberField;

    public LevelData leveldata;

    [ContextMenu("Do Save")]
    public void SaveLevel()
    {
        PlayerPrefs.SetString("LevelName", LevelNameField.text);
        PlayerPrefs.SetString("LevelReward", LevelRewardField.text);
        PlayerPrefs.SetString("EnemyNumber", EnemyNumberField.text);

        leveldata.LevelName = LevelName;
        leveldata.LevelReward = LevelReward;
        leveldata.EnemyNumber = EnemyNumber;

        string json = JsonUtility.ToJson(leveldata);
        Debug.Log(json);
        PlayerPrefs.SetString(LevelData.SAVE_ID, json);

        PlayerPrefs.Save();

    }

    [ContextMenu("Do SaveFile")]
    public void SaveFile()
    {
        string path = "Assets/Resources/Levels/Level_01.txt";
        StreamWriter writer = new StreamWriter(path, false);

        leveldata.LevelName = LevelNameField.text;
        leveldata.LevelReward = LevelRewardField.text;
        leveldata.EnemyNumber = EnemyNumberField.text;
        

        string json = JsonUtility.ToJson(leveldata);
        writer.WriteLine(json);
        writer.Close();

        AssetDatabase.ImportAsset(path);
    }
}
