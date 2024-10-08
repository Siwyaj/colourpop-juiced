using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class data : MonoBehaviour
{
    public static bool? selected;
    int stagenr;
    public static float timeSinceLastPress;
    public Vector3 xyYCoordinate;
    public Color P3Color;
    public float xyYDistanceToBasexyY;
    public float P3ColorDistanceToBase;
    float timeAlive;



    string path = Application.dataPath + "/CPDataLogTemp.csv";

    private void FixedUpdate()
    {
        timeAlive += Time.deltaTime;
        timeSinceLastPress += Time.deltaTime;
    }
    private void OnDestroy()//This has to be made into a funtion
    {
        if (!File.Exists(path))
        {
            File.WriteAllText(path, "");
        }

        stagenr = 999;//for errors
        if (LevelScript.stage2)
        {
            stagenr = 2;
        }
        else
        {
            stagenr = 1;
        }
        


        string dataToBewritten = "\n"+DemographicInfoKeeper.participantNumber + ";" + DemographicInfoKeeper.participantName + ";" + System.DateTime.Now + ";" + timeAlive + ";" + timeSinceLastPress + ";" + xyYCoordinate[0] + ";" + xyYCoordinate[1] + ";" + xyYCoordinate[2] + ";" + P3Color[0] + ";" + P3Color[1] + ";" + P3Color[2] + ";" + DataManager.setBaseColorxyY[0] + ";" + DataManager.setBaseColorxyY[1] + ";" + DataManager.setBaseColorxyY[2] + ";" + DataManager.baseColor[0] + ";" + DataManager.baseColor[1] + ";" + DataManager.baseColor[2] + ";" + selected+ ";"+ xyYDistanceToBasexyY+";"+ P3ColorDistanceToBase+";"+ DataManager.levelNumber+";"+ stagenr + ";";

        if (selected.HasValue && selected.Value)
        {
            timeSinceLastPress = 0;
        }

        File.AppendAllText(path, dataToBewritten);
        //File.AppendAllText(IntroScript.pathToDataLog, dataToBewritten);

    }

    public void LogDataForPoint()
    {
        Debug.Log("Successfully logged data for point(*100): " + xyYCoordinate*100);
    }
}
