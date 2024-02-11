using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InterfaceManager : MonoBehaviour
{
    public TextMeshProUGUI label;
    public void PrintMessage(string msg)
       {
        label.text = msg;
        
       }

}
