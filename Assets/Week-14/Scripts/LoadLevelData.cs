using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLevelData : MonoBehaviour
{
    public string LevelName;
    public string LevelReward;
    public string EnemyNumber;

    public LevelData leveldata;

    [ContextMenu("Do Load")]
    public void LoadLevel()
    {
        LevelName = PlayerPrefs.GetString("LevelName");
        LevelReward = PlayerPrefs.GetString("LevelReward");
        EnemyNumber = PlayerPrefs.GetString("EnemyNumber");

        float x = PlayerPrefs.GetFloat("position-x");
        float y = PlayerPrefs.GetFloat("position-y");
        float z = PlayerPrefs.GetFloat("position-z");

        leveldata = JsonUtility.FromJson<LevelData>(PlayerPrefs.GetString(LevelData.SAVE_ID));
    }

    [ContextMenu("Do FileLoad")]
    public void LoadFile()
    {
        TextAsset userDataFile = Resources.Load<TextAsset>("Save");
        leveldata = JsonUtility.FromJson<LevelData>(userDataFile.text);
    }
}
