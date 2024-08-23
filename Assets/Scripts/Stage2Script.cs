using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UIElements;

public class Stage2Script : MonoBehaviour
{
    public GameObject Blackbox;
    public Color convertedColor;
    

    public List<Vector3> stage2Colors = new List<Vector3>();

    public GameObject prefab;
    public GameObject background;
    public Color BackgroundColor;

    // Start is called before the first frame update
    void Start()
    {
        background.GetComponent<SpriteRenderer>().color = DataManager.baseColor;
        
        
        stage2Spawn();
    }

    
    public void stage2Spawn()
    {
        stage2Colors = Blackbox.GetComponent<CalculateStage2coordinates>().Stage2Coordinates(ButtonClick.selectedList, ButtonClick.createdObjects, DataManager.setBaseColorxyY);

        Debug.Log("stage2Colors.Count:" + stage2Colors.Count);
        foreach(Vector3 Stage2Coordinate in stage2Colors)
        {
            convertedColor = Blackbox.GetComponent<ConvertToP3>().Convert(Stage2Coordinate);
            GameObject circle = Instantiate(prefab, new Vector2(Random.Range(-5.27f, 9.20f), Random.Range(-3.59f, 3.59f)), Quaternion.identity);

            circle.GetComponent<Prefab_info>().xyYCoordinate = Stage2Coordinate; // skal ikke være random
            circle.GetComponent<Prefab_info>().P3Color = convertedColor;
            circle.GetComponent<Prefab_info>().xyYDistanceToBasexyY = CalculatexyYDistance(DataManager.setBaseColorxyY, circle.GetComponent<Prefab_info>().xyYCoordinate);
            circle.GetComponent<Prefab_info>().P3ColorDistanceToBase = CalculateP3Distance(BackgroundColor, convertedColor);

            prefab.GetComponent<SpriteRenderer>().color = convertedColor;
        }
        /*
        if (stage2Colors.Count > 0)
        {
           for (int i = 0; i < stage2Colors.Count; i++)
            {
                Debug.Log("i=" + i);
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
                circle.GetComponent<Prefab_info>().xyYDistanceToBasexyY = CalculatexyYDistance(DataManager.setBaseColorxyY, circle.GetComponent<Prefab_info>().xyYCoordinate);
                circle.GetComponent<Prefab_info>().P3ColorDistanceToBase = CalculateP3Distance(BackgroundColor, convertedColor);

                stage2Colors.RemoveAt(randomPoint);
            }
        }*/

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
