using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class LoadData : MonoBehaviour
{
    public int score;
    public string username;
    public float balance;

    public Data data;

    [ContextMenu("Do Load")]
    public void LoadDataTest()
    {
        score = PlayerPrefs.GetInt("score", 10000);
        username = PlayerPrefs.GetString("username");
        balance = PlayerPrefs.GetFloat("balance");

        float x = PlayerPrefs.GetFloat("position-x");
        float y = PlayerPrefs.GetFloat("position-y");
        float z = PlayerPrefs.GetFloat("position-z");

        //transform.position = new Vector3(x, y, z);

        string positionString = PlayerPrefs.GetString("position", "0 0 0");
        //axis[0] is x axis[1] is y axis[2] is z
        string[] axis = positionString.Split(' ');
        transform.position = new Vector3(float.Parse(axis[0]), float.Parse(axis[1]), float.Parse(axis[2]));

        data = JsonUtility.FromJson<Data>(PlayerPrefs.GetString(Data.SAVE_ID));
    }

    [ContextMenu("Do File Load")]
    public void LoadFileTest()
    {
        TextAsset userDataFile = Resources.Load<TextAsset>("SaveData");
        data = JsonUtility.FromJson<Data>(userDataFile.text);
    }
}
