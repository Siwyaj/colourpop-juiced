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



    string path = Application.dataPath + "/CPTemp.csv";

    private void FixedUpdate()
    {
        timeAlive += Time.deltaTime;
        timeSinceLastPress += Time.deltaTime;
    }

    public void LogDataForPoint()
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



        string dataToBewritten = "\n" + DemographicInfoKeeper.participantNumber + ";" + 
            DemographicInfoKeeper.participantName + ";" + 
            System.DateTime.Now + ";" + timeAlive + ";" + 
            timeSinceLastPress + ";" + 
            xyYCoordinate[0] + ";" + 
            xyYCoordinate[1] + ";" + 
            xyYCoordinate[2] + ";" + 
            P3Color[0] + ";" + 
            P3Color[1] + ";" + 
            P3Color[2] + ";" + 
            DataManager.setBaseColorxyY[0] + ";" + 
            DataManager.setBaseColorxyY[1] + ";" + 
            DataManager.setBaseColorxyY[2] + ";" + 
            DataManager.baseColor[0] + ";" + 
            DataManager.baseColor[1] + ";" + 
            DataManager.baseColor[2] + ";" + 
            selected + ";" +
            xyYDistanceToBasexyY + ";" + 
            P3ColorDistanceToBase + ";" + 
            DataManager.levelNumber + ";" +
            DataManager.StageNr + ";" +
            DemographicInfoKeeper.participantAge + ";" +
            DemographicInfoKeeper.participantSex + ";" +
            DemographicInfoKeeper.needForEyeCorrection + ";" +
            DemographicInfoKeeper.nearFarSight + ";" +
            DemographicInfoKeeper.eyeColor + ";" +
            DemographicInfoKeeper.countryOfBirth + ";" +
            DemographicInfoKeeper.recidingCountry + ";" +
            transform.position.x + ";" +
            transform.position.y
            ;

        if (selected.HasValue && selected.Value)
        {
            timeSinceLastPress = 0;
        }
        Debug.Log("logged: " + dataToBewritten);
        File.AppendAllText(path, dataToBewritten);
    }
}
