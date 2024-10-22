using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.Collections;
using Unity.VisualScripting;


public class SpawnManager : MonoBehaviour
{


    public GameObject background;
    //Method for converting xy to sRGB
    public GameObject colorConvert;
    public GameObject BlackBox2;
    //The converted color
    public Color convertedColor;
    public int numberOfPoints = 0;
    
    //public static Dictionary<Vector2, bool> createdPoints = new Dictionary<Vector2, bool>();
    public static List<GameObject> points = new List<GameObject>();

    public static List<Vector2> spawnPoints = new List<Vector2>
    {
        new Vector2(-8.97f,2.29f),
        new Vector2(-5.17f,0.64f),
        new Vector2(-3.15f,-0.48f),
        new Vector2(1.24f,3.69f),
        new Vector2(1.08f,0.14f),
        new Vector2(-9.03f,-2.37f),
        new Vector2(-4.96f,3.70f),
        new Vector2(-4.64f,-3.23f),
        new Vector2(0.86f, -3.14f),
        new Vector2(-2.85f,2.05f)

    };

    //Colour centerpoints for creating colours
   
    

    public Color testColor;
    public static Color Backgroundcolor;

    public GameObject prefab;
    

    // Start is called before the first frame update
    void Start()
    {
        SpawnNPoint(8);


    }
    public void SpawnNPoint(int numberOfPointToSpawn)
    {
        if (numberOfPointToSpawn > DataManager.xyYPointsList.Count)
        {
            numberOfPointToSpawn = DataManager.xyYPointsList.Count;

        }

        for (var i = 0; i < numberOfPointToSpawn; i++)
        {


            //finds P3 color and spawns point at the ith location
            convertedColor = BlackBox2.GetComponent<ConvertToP3>().Convert(DataManager.xyYPointsList[0]);
            GameObject point = Instantiate(prefab, spawnPoints[i], Quaternion.identity);
            point.GetComponent<SpriteRenderer>().color = convertedColor;

            //sets data for poit
            point.GetComponent<data>().xyYCoordinate = DataManager.xyYPointsList[0];
            point.GetComponent<data>().P3Color = convertedColor;
            point.GetComponent<data>().xyYDistanceToBasexyY = CalculatexyYDistance(DataManager.setBaseColorxyY, point.GetComponent<data>().xyYCoordinate);
            point.GetComponent<data>().P3ColorDistanceToBase = CalculateP3Distance(Backgroundcolor, convertedColor);

            //adds the point xyY to list over created points in buttonclick script, as it handles which have been selected.
            ButtonClick.createdObjects.Add(point);
            ButtonClick.createdObjectsxyY.Add(point.GetComponent<data>().xyYCoordinate);

            //Remove the spawned color from to be spawn list
            DataManager.xyYPointsList.RemoveAt(0);
        }

    }
    
    public float CalculatexyYDistance(Vector3 basexyYCoordinate, Vector3 xyYcoordinate)
    {
        return Vector3.Distance(basexyYCoordinate, xyYcoordinate);
    }

    public float CalculateP3Distance(Color baseP3, Color P3)
    {
        Vector3 baseP3Vector = new Vector3(baseP3[0], baseP3[1], baseP3[2]);
        Vector3 P3Vector = new Vector3(P3[0], P3[1], P3[2]);
        return Vector3.Distance(baseP3Vector, P3Vector);
    }


}
