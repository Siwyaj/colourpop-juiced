using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static int ResetCounter = 0;
    public int counter;
    public int destroyedCounter;
    public GameObject manager;
    public static int StageNr;
    public static int levelNumber;
    public static Color baseColor;

    public static GameObject LevelGameObject;

    public GameObject Blackbox;

    public float timer;


    public static Vector3 setBaseColorxyY;
    public static List<Vector3> xyYPointsList = new List<Vector3>();
    public GameObject background;

    public static List<List<Vector3>> levelResults = new List<List<Vector3>>() { 
    new List<Vector3>(), //level1
    new List<Vector3>(), //level2
    new List<Vector3>(), //level3
    new List<Vector3>(), //level4
    new List<Vector3>(), //level5
    new List<Vector3>(), //level6
    new List<Vector3>(), //level7
    new List<Vector3>(), //level8
    new List<Vector3>(), //level9
    new List<Vector3>(), //level10
    new List<Vector3>(), //level11
    new List<Vector3>(), //level12
    new List<Vector3>(), //level13
    new List<Vector3>(), //level14
    new List<Vector3>(), //level15
    new List<Vector3>(), //level16
    new List<Vector3>(), //level17
    new List<Vector3>(), //level18
    new List<Vector3>(), //level19
    new List<Vector3>(), //level20
    new List<Vector3>(), //level21
    new List<Vector3>(), //level22
    };

    public void ResetLevelResults()
    {
        foreach(List<Vector3> list in levelResults)
        {
            list.Clear();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        background.GetComponent<SpriteRenderer>().color = baseColor;

        string path = Application.dataPath + "/CPLog.csv";

        if (!File.Exists(path))
        {
            File.WriteAllText(path, "part_nr;" +
                "part_name;" +
                "date_time;" +
                "t_alive;" +
                "dt_last;" +
                "xyY(x);" +
                "xyY(y);" +
                "xyY(Y);" +
                "P3_R;" +
                "P3_G;" +
                "P3_B;" +
                "base_P3_x;" +
                "base_P3_y;" +
                "base_P3_Y;" +
                "base_P3_R;" +
                "base_P3_G;" +
                "base_P3_B;" +
                "differentiated?;" +
                "dist_base_xyY;" +
                "dist_base_P3;" +
                "lvl_nr;stg_nr;" +
                "part_age;" +
                "part_sex;" +
                "part_eye_correct;" +
                "part_nearfar;" +
                "part_eye_color;" +
                "part_birth;" +
                "part_reciding");
        }


    }

    // Update is called once per frame
    void Update()

    {
        timer = (timer + Time.deltaTime);
        if (ResetCounter == 13)
        {

            if (!LevelScript.stage2)
            {
                LevelScript.stage2 = true;
                StageNr = 2;
                SceneManager.LoadScene("Stage2", LoadSceneMode.Single);
                ResetCounter = 0;
            }
            



            
           
        }

        counter = manager.GetComponent<SpawnManager>().numberOfPoints;
        
        destroyedCounter = ButtonClick.Destroycounter;
        

    }

   
    

}
