using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UIElements;

public class Stage2Script : MonoBehaviour
{
    public GameObject Blackbox;
    public Color convertedColor;
    public Vector2 blue = new Vector2(0.2f, 0.14f);
    public Vector2 red = new Vector2(0.55f, 0.4f);
    public Vector2 green = new Vector2(0.3f, 0.6f);
    public Vector3 baseColor = new Vector3(0.2296f, 0.2897f, 0.2815f);

    public static List<Vector3> stage2Colors = new List<Vector3>();

    public GameObject prefab;
    public GameObject background;
    public Color BackgroundColor;

    // Start is called before the first frame update
    void Start()
    {
        if (DataManager.levelNumber == 1 || DataManager.levelNumber == 3 || DataManager.levelNumber == 5)
        {
            BackgroundColor = Blackbox.GetComponent<ConvertToP3>().Convert(baseColor);
            background.GetComponent<SpriteRenderer>().color = BackgroundColor;
        }
        /*else if (DataManager.levelNumber == 4 || DataManager.levelNumber == 2 || DataManager.levelNumber == 7)
        {
            BackgroundColor = Blackbox.GetComponent<ConvertToP3>().Convert(red);
            background.GetComponent<SpriteRenderer>().color = BackgroundColor;
        }
        else if (DataManager.levelNumber == 6 || DataManager.levelNumber == 8 || DataManager.levelNumber == 9)
        {
            BackgroundColor = Blackbox.GetComponent<ConvertToP3>().Convert(green);
            background.GetComponent<SpriteRenderer>().color = BackgroundColor;

        }*/


        //Debug.Log(ButtonClick.stage2Colors);

        stage2Colors = Blackbox.GetComponent<CalculateStage2coordinates>().Stage2Coordinates(ButtonClick.selectedList, ButtonClick.createdObjects, baseColor);



        stage2Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    public void stage2Spawn()
    {
        if(stage2Colors.Count > 0)
        {
           for (int i = 0; i < stage2Colors.Count; i++)
            {
                var randomPoint = Random.Range(0, (stage2Colors.Count - 1));
                convertedColor = Blackbox.GetComponent<ConvertToP3>().Convert(stage2Colors[randomPoint]);

                prefab.GetComponent<SpriteRenderer>().color = convertedColor;

                Vector2 randomspawn = new Vector2(Random.Range(-5.27f, 9.20f), Random.Range(-3.59f, 3.59f));

                for (int j = 0; i < 10; i++)
                {
                    if(Physics2D.OverlapCircle(randomspawn,0.5f) == null)
                    {
                        break;
                    }
                    else
                    {
                        randomspawn = new Vector2(Random.Range(-9f, 9f), Random.Range(-4f, 2.82f));
                    }
                }

                GameObject circle = Instantiate(prefab, new Vector2(randomspawn[0], randomspawn[1]),Quaternion.identity);
                circle.GetComponent<Prefab_info>().xyYCoordinate = stage2Colors[randomPoint]; // skal ikke være random
                circle.GetComponent<Prefab_info>().P3Color = convertedColor;
                circle.GetComponent<Prefab_info>().xyYDistanceToBasexyY = CalculatexyYDistance(baseColor, circle.GetComponent<Prefab_info>().xyYCoordinate);
                circle.GetComponent<Prefab_info>().P3ColorDistanceToBase = CalculateP3Distance(BackgroundColor, convertedColor);

                stage2Colors.RemoveAt(randomPoint);
            }
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
