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
    
    public static Dictionary<Vector2, bool> createdPoints = new Dictionary<Vector2, bool>();
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
    public Vector2 blue = new Vector2(0.2f, 0.14f);
    public Vector2 red = new Vector2(0.55f, 0.4f);
    public Vector2 green = new Vector2(0.3f, 0.6f);
    public Vector3 baseColor = new Vector3(0.2296f, 0.2897f, 0.2815f);

    public Color testColor;
    public Color Backgroundcolor;

    public GameObject prefab;
    

    // Start is called before the first frame update
    void Start()
    {
        createdPoints.Clear();


        if (DataManager.levelNumber == 1 || DataManager.levelNumber == 3 || DataManager.levelNumber == 5)
        {
            Debug.Log("debug" + " " + ColourCreator.bluepoints.Count);
            Backgroundcolor = BlackBox2.GetComponent<ConvertToP3>().Convert(baseColor);
            background.GetComponent<SpriteRenderer>().color = Backgroundcolor;
            Bluespawn(9, 10);
            
        }
        else if (DataManager.levelNumber == 4 || DataManager.levelNumber == 2 || DataManager.levelNumber == 7)
        {
            Redspawn(10, 10);
            Backgroundcolor = BlackBox2.GetComponent<ConvertToP3>().Convert(red);
            background.GetComponent<SpriteRenderer>().color = Backgroundcolor;
        }
        else if (DataManager.levelNumber == 6 || DataManager.levelNumber == 8 || DataManager.levelNumber == 9)
        {
            Greenspawn(9, 10);
            Backgroundcolor = BlackBox2.GetComponent<ConvertToP3>().Convert(green);
            background.GetComponent<SpriteRenderer>().color = Backgroundcolor;

        }

    }

    
    public void Bluespawn(int minSpawn, int maxSpawn)
    {
        numberOfPoints = Random.Range(minSpawn, maxSpawn);

        if (numberOfPoints > ColourCreator.bluepoints.Count)
        {
            numberOfPoints = ColourCreator.bluepoints.Count;
            
        }

        for (var i = 0; i < numberOfPoints; i++)
        {
            
            convertedColor = BlackBox2.GetComponent<ConvertToP3>().Convert(ColourCreator.bluepoints[0]);
   
            //Set the colour of the prefab
            prefab.GetComponent<SpriteRenderer>().color = convertedColor;

            GameObject point = Instantiate(prefab, spawnPoints[i], Quaternion.identity);


            //Set IDs of prefab to xy
            point.GetComponent<Prefab_info>().xyYCoordinate = ColourCreator.bluepoints[0];
            point.GetComponent<Prefab_info>().P3Color = convertedColor;
            point.GetComponent<Prefab_info>().xyYDistanceToBasexyY = CalculatexyYDistance(baseColor, point.GetComponent<Prefab_info>().xyYCoordinate);
            point.GetComponent<Prefab_info>().P3ColorDistanceToBase = CalculateP3Distance(Backgroundcolor, convertedColor);


            ButtonClick.createdObjects.Add(point.GetComponent<Prefab_info>().xyYCoordinate);

            createdPoints.Add(ColourCreator.bluepoints[0], false);
            

            //Remove the colour just used so we do not repeat colours
            ColourCreator.bluepoints.RemoveAt(0);
        }

        Debug.Log(ColourCreator.bluepoints.Count);
    }

    public void Redspawn(int minSpawn, int maxSpawn)
    {

        numberOfPoints = Random.Range(minSpawn, maxSpawn);

        
        if (numberOfPoints > ColourCreator.redpoints.Count)
        {
            numberOfPoints = ColourCreator.redpoints.Count;
        }

        for (var i = 0; i < numberOfPoints; i++)
        {
            var randomXY = Random.Range(0, (ColourCreator.redpoints.Count - 1));
            convertedColor = BlackBox2.GetComponent<ConvertToP3>().Convert(ColourCreator.redpoints[randomXY]);

            prefab.GetComponent<SpriteRenderer>().color = convertedColor;

            //Vector2 randomspawn = new Vector2(Random.Range(-9f, 2.10f), Random.Range(-4f, 2.82f));

            if (Physics2D.OverlapCircle(spawnPoints[i], 0.5f) == null)
            {
                GameObject point = Instantiate(prefab, spawnPoints[i], Quaternion.identity);

                //Set ID of prefab to xy
                point.GetComponent<Prefab_info>().xyYCoordinate = ColourCreator.redpoints[randomXY];
            }
            



            createdPoints.Add(ColourCreator.redpoints[randomXY], false);
            
            ColourCreator.redpoints.RemoveAt(randomXY);

            Debug.Log(ColourCreator.redpoints.Count);
        }


    }
    /*
    public void Redspawn2(int minSpawn, int maxSpawn)
    {

        numberOfPoints = Random.Range(minSpawn, maxSpawn);

        
        if (numberOfPoints > ColourCreator.redpoints2.Count)
        {
            numberOfPoints = ColourCreator.redpoints2.Count;
        }

        for (var i = 0; i < numberOfPoints; i++)
        {
            var randomXY = Random.Range(0, (ColourCreator.redpoints2.Count - 1));
            convertedColor = BlackBox2.GetComponent<ConvertToP3>().Convert(ColourCreator.redpoints2[randomXY]);

            prefab.GetComponent<SpriteRenderer>().color = convertedColor;

            Vector2 randomspawn = new Vector2(Random.Range(-9f, 2.10f), Random.Range(-4f, 2.82f));

            if (Physics2D.OverlapCircle(randomspawn, 0.5f) == null)
            {
                GameObject point = Instantiate(prefab, new Vector2(randomspawn[0], randomspawn[1]), Quaternion.identity);

                //Set ID of prefab to xy
                point.GetComponent<Prefab_info>().id = ColourCreator.redpoints2[randomXY];
            }
            else
            {
                Vector2 newRandomspawn = new Vector2(Random.Range(-9f, 2.10f), Random.Range(-4f, 2.82f));

                GameObject point = Instantiate(prefab, new Vector2(newRandomspawn[0], newRandomspawn[1]), Quaternion.identity);
                //Set ID of prefab to xy
                point.GetComponent<Prefab_info>().id = ColourCreator.redpoints2[randomXY];
            }

 
            createdPoints.Add(ColourCreator.redpoints2[randomXY], false);
            
            ColourCreator.redpoints2.RemoveAt(randomXY);

            Debug.Log(ColourCreator.redpoints2.Count);
        }


    }*/

    /*
    public void Redspawn3(int minSpawn, int maxSpawn)
    {

        numberOfPoints = Random.Range(minSpawn, maxSpawn);

        
        if (numberOfPoints > ColourCreator.redpoints3.Count)
        {
            numberOfPoints = ColourCreator.redpoints3.Count;
        }

        for (var i = 0; i < numberOfPoints; i++)
        {
            var randomXY = Random.Range(0, (ColourCreator.redpoints3.Count - 1));
            convertedColor = BlackBox2.GetComponent<ConvertToP3>().Convert(ColourCreator.redpoints3[randomXY]);

            prefab.GetComponent<SpriteRenderer>().color = convertedColor;

            Vector2 randomspawn = new Vector2(Random.Range(-9f, 2.10f), Random.Range(-4f, 2.82f));

            if (Physics2D.OverlapCircle(randomspawn, 0.5f) == null)
            {
                GameObject point = Instantiate(prefab, new Vector2(randomspawn[0], randomspawn[1]), Quaternion.identity);

                //Set ID of prefab to xy
                point.GetComponent<Prefab_info>().id = ColourCreator.redpoints3[randomXY];
            }
            else
            {
                Vector2 newRandomspawn = new Vector2(Random.Range(-9f, 2.10f), Random.Range(-4f, 2.82f));

                GameObject point = Instantiate(prefab, new Vector2(newRandomspawn[0], newRandomspawn[1]), Quaternion.identity);
                //Set ID of prefab to xy
                point.GetComponent<Prefab_info>().id = ColourCreator.redpoints3[randomXY];
            }


            createdPoints.Add(ColourCreator.redpoints3[randomXY], false);
            ColourCreator.redpoints3.RemoveAt(randomXY);

            Debug.Log(ColourCreator.redpoints3.Count);
        }


    }
    */

    public void Greenspawn(int minSpawn, int maxSpawn)
    {

        numberOfPoints = Random.Range(minSpawn, maxSpawn);

        if (numberOfPoints > ColourCreator.greenpoints.Count)
        {
            numberOfPoints = ColourCreator.greenpoints.Count;
        }


        for (var i = 0; i < numberOfPoints; i++)
        {


            var randomXY = Random.Range(0, (ColourCreator.greenpoints.Count - 1));
            convertedColor = BlackBox2.GetComponent<ConvertToP3>().Convert(ColourCreator.greenpoints[randomXY]);


            prefab.GetComponent<SpriteRenderer>().color = convertedColor;

            //Vector2 randomspawn = new Vector2(Random.Range(-9f, 2.10f), Random.Range(-4f, 2.82f)); ;

            if (Physics2D.OverlapCircle(spawnPoints[i], 0.5f) == null)
            {
                GameObject point = Instantiate(prefab, spawnPoints[i], Quaternion.identity);

                //Set ID of prefab to xy
                point.GetComponent<Prefab_info>().xyYCoordinate = ColourCreator.greenpoints[randomXY];
            }
            else
            {
                Vector2 newRandomspawn = new Vector2(Random.Range(-9f, 2.10f), Random.Range(-4f, 2.82f));

                GameObject point = Instantiate(prefab, new Vector2(newRandomspawn[0], newRandomspawn[1]), Quaternion.identity);
                //Set ID of prefab to xy
                point.GetComponent<Prefab_info>().xyYCoordinate = ColourCreator.greenpoints[randomXY];
            }

            //Save coordinates and bool for each point created

            if (!createdPoints.ContainsKey(ColourCreator.greenpoints[randomXY]))
            {
                createdPoints.Add(ColourCreator.greenpoints[randomXY], false);
            }
            
            
            ColourCreator.greenpoints.RemoveAt(randomXY);

            Debug.Log(ColourCreator.greenpoints.Count);
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
