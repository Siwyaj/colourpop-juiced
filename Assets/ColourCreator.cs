using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourCreator : MonoBehaviour
{
    public Vector3 baseColor = new Vector3(0.2296f, 0.2897f, 0.2815f);


    public Vector3 blue = new Vector2(0.2f, 0.14f);
    public Vector3 red = new Vector2(0.55f,0.4f);
    public Vector3 green = new Vector2(0.3f, 0.6f); 
    public GameObject BlackBox2;
    public static List<Vector3> bluepoints = new List<Vector3>();
    public static List<Vector3> redpoints = new List<Vector3>();
    public static List<Vector3> greenpoints = new List<Vector3>();


    public static List<Vector2> redpoints2 = new List<Vector2>();
    public static List<Vector2> redpoints3 = new List<Vector2>();


    public static List<Vector2> spawnPoints = new List<Vector2>();


    // Start is called before the first frame update
    void Start()
    {
        //bluepoints = BlackBox2.GetComponent<CalculateCIE1931xyCoordinates>().CreateCoordinates(blue, 0.005f);
        bluepoints = BlackBox2.GetComponent<CalculatexyYCoordinates>().CreateCoordinates(baseColor);
        Debug.Log(bluepoints.Count);

        redpoints = BlackBox2.GetComponent<CalculatexyYCoordinates>().CreateCoordinates(red);
        //redpoints2 = BlackBox2.GetComponent<CalculateCIE1931xyCoordinates>().CreateCoordinates(red, 0.001f);
        //redpoints3 = BlackBox2.GetComponent<CalculateCIE1931xyCoordinates>().CreateCoordinates(red, 0.001f);
        
        greenpoints = BlackBox2.GetComponent<CalculatexyYCoordinates>().CreateCoordinates(green);
       
    }

    private void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
