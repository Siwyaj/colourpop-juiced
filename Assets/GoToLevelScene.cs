using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoToLevelScene : MonoBehaviour
{
    public int buttonLevel;
    GameObject blackBox;
    public GameObject circleColor;
    Color levelP3Color;
    public Vector3 baseVector;

    List<Vector3> xyYBaseColors = new List<Vector3>()
    {
        new Vector3(210f/255f, 121f/255f, 117f/255f), //Level1
        new Vector3(0.2296f, 0.2897f, 0.2815f), //Level2
        new Vector3(0.2296f, 0.2897f, 0.2815f), //Level3
        new Vector3(0.2296f, 0.2897f, 0.2815f), //Level4
        new Vector3(0.2296f, 0.2897f, 0.2815f), //Level5
        new Vector3(0.2296f, 0.2897f, 0.2815f), //Level6
        new Vector3(0.2296f, 0.2897f, 0.2815f), //Level7
        new Vector3(0.2296f, 0.2897f, 0.2815f), //Level8
        new Vector3(0.2296f, 0.2897f, 0.2815f), //Level9
        new Vector3(0.2296f, 0.2897f, 0.2815f), //Level10
        new Vector3(0.2296f, 0.2897f, 0.2815f), //Level11
        new Vector3(0.2296f, 0.2897f, 0.2815f), //Level12
        new Vector3(0.2296f, 0.2897f, 0.2815f), //Level13
        new Vector3(0.2296f, 0.2897f, 0.2815f), //Level14
        new Vector3(0.2296f, 0.2897f, 0.2815f), //Level14
        new Vector3(0.2296f, 0.2897f, 0.2815f), //Level15
        new Vector3(0.2296f, 0.2897f, 0.2815f), //Level16
        new Vector3(0.2296f, 0.2897f, 0.2815f), //Level17
        new Vector3(0.2296f, 0.2897f, 0.2815f), //Level18
        new Vector3(0.2296f, 0.2897f, 0.2815f), //Level19
        new Vector3(0.2296f, 0.2897f, 0.2815f), //Level20
        new Vector3(0.2296f, 0.2897f, 0.2815f), //Level21
        new Vector3(0.2296f, 0.2897f, 0.2815f), //Level22
    };
    public List<Vector3> levelScore = new List<Vector3>();



    void Start()
    {
        baseVector = xyYBaseColors[buttonLevel - 1];
        blackBox = GameObject.FindGameObjectsWithTag("Blackbox")[0];
        levelP3Color = blackBox.GetComponent<ConvertToP3>().convertBasesRGBToP3(baseVector);
        circleColor.GetComponent<RawImage>().color = levelP3Color;
    }

    
    

    public void setThisLevelInDataManager()
    {
        Debug.Log("DataManager data set");
        DataManager.baseColor = levelP3Color;
        DataManager.setBaseColorxyY = baseVector;
        DataManager.levelNumber = buttonLevel;

        DataManager.baseColor = levelP3Color;
        DataManager.setBaseColorxyY = baseVector;
        CalculatexyYCoordinates blackboxComponent = blackBox.GetComponent<CalculatexyYCoordinates>();
        Vector3 xyYBaseFromButton = baseVector;


        DataManager.xyYPointsList = blackboxComponent.CreateCoordinates(xyYBaseFromButton);


    }
}
