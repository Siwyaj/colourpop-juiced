using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DataManager : MonoBehaviour
{
    public static int ResetCounter = 0;
    public int counter;
    public int destroyedCounter;
    public GameObject manager;
    public static int levelNumber;
    public static Color baseColor;

    

    public GameObject Blackbox;

    public float timer;


    public static Vector3 setBaseColorxyY;
    public static List<Vector3> xyYPointsList = new List<Vector3>();
    public GameObject background;



    // Start is called before the first frame update
    void Start()
    {
        background.GetComponent<Image>().color = baseColor;
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
                levelNumber = 2;
                SceneManager.LoadScene("Stage2", LoadSceneMode.Single);
            }
            else
            {

                SceneManager.LoadScene("LevelSelect", LoadSceneMode.Single);
            }



            ResetCounter = 0;
           
        }

        counter = manager.GetComponent<SpawnManager>().numberOfPoints;
        
        destroyedCounter = ButtonClick.Destroycounter;
        

    }

   
    

}
