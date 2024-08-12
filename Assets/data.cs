using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class data : MonoBehaviour
{
    public Vector3 xyYCoordinate;
    public Color P3Color;
    public float xyYDistanceToBasexyY;
    public float P3ColorDistanceToBase;



    string path = Application.dataPath + "/CPDataLogTemp.csv";

    private void OnDestroy()
    {
        if (!File.Exists(path))
        {
            File.WriteAllText(path, "\n");
        }
        
        string dataToBewritten = IntroScript.Participant + ";" + System.DateTime.Now+";"+ xyYCoordinate + ";"+ P3Color+";"+ButtonClick.SubmitButtonPress+";"+ xyYDistanceToBasexyY+";"+ P3ColorDistanceToBase+"\n";
        File.AppendAllText(path, dataToBewritten);
        Debug.Log("Color: " + xyYCoordinate * 10 + " was destroyed, logging data...");
    }
}
