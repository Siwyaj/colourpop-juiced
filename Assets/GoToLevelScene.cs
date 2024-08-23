using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GoToLevelScene : MonoBehaviour
{
    public int buttonLevel;
    GameObject blackBox;
    public GameObject circleColor;
    Color levelP3Color;
    List<Vector3> xyYBaseColors = new List<Vector3>()
    {
        new Vector3(0.2296f, 0.2897f, 0.2815f), //Level1
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



    void Start()
    {
        blackBox = GameObject.FindGameObjectsWithTag("Blackbox")[0];
        levelP3Color = blackBox.GetComponent<ConvertToP3>().Convert(xyYBaseColors[buttonLevel - 1]);
        circleColor.GetComponent<RawImage>().color = levelP3Color;
    }

    
    public void goToStage1()
    {

        DataManager.baseColor = levelP3Color;
        DataManager.setBaseColorxyY = xyYBaseColors[buttonLevel - 1];
        CalculatexyYCoordinates blackboxComponent = blackBox.GetComponent<CalculatexyYCoordinates>();
        Vector3 xyYBaseFromButton = xyYBaseColors[buttonLevel - 1];

        Debug.Log(blackboxComponent);
        Debug.Log(xyYBaseFromButton);

        DataManager.xyYPointsList = blackboxComponent.CreateCoordinates(xyYBaseFromButton);
        
        
        SceneManager.LoadScene("Stage1", LoadSceneMode.Single);
        DataManager.levelNumber = 1;

    }
}
