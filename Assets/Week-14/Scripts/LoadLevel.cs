using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    public string levelToLoadName;
    public int levelToLoadIndex;
    public bool loadLevelByName;

    // Start is called before the first frame update
    void Start()
    {
        if (loadLevelByName)
        {
            //Loads the scene by the name of the scene
            SceneManager.LoadScene(levelToLoadName);
        }
        else
        {
            //Loads the scene by the index of the scene
            //in the build settings window
            SceneManager.LoadScene(levelToLoadIndex);
        }
    }
}
