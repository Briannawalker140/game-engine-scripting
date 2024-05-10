using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    public int score;
    public string username;
    public float balance
    {
        get
        {
            if (_balance < 0) _balance = 1000;
            return _balance;
        }
        set
        {
            _balance = value;
            PlayerPrefs.SetFloat("balance", _balance);
            //AudioPlayer.PlaySound...
        }
    }
    private float _balance;

    public Data data;

    [ContextMenu("Do Save")]
    public void SaveDataTest()
    {
        PlayerPrefs.SetInt("score", score);
        PlayerPrefs.SetString("username", username);
        PlayerPrefs.SetFloat("balance", balance);

        string position = string.Format("{0} {1} {2}", transform.position.x, transform.position.y, transform.position.z);
        PlayerPrefs.SetString("position", position);

        PlayerPrefs.SetFloat("position-x", transform.position.x);
        PlayerPrefs.SetFloat("position-y", transform.position.y);
        PlayerPrefs.SetFloat("position-z", transform.position.z);

        data.score = score;
        data.username = username;
        data.balance = balance;
        data.position = transform.position;

        string json = JsonUtility.ToJson(data);
        Debug.Log(json);
        PlayerPrefs.SetString(Data.SAVE_ID, json);

        PlayerPrefs.Save();

    }

    [ContextMenu("Do File Save")]
    public void SaveToFile()
    {
        string path = "Assets/Resources/SavaData.txt";
        StreamWriter writer = new StreamWriter(path, false);

        data.score = score;
        data.username = username;
        data.balance = balance;
        data.position = transform.position;

        string json = JsonUtility.ToJson(data);
        writer.WriteLine(json);
        writer.Close();

        AssetDatabase.ImportAsset(path);
    }
}
