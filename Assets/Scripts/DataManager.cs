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
    public GameObject background;
    public static int levelNumber;
    public Vector2 blue = new Vector2(0.2f, 0.14f);
    public Vector3 baseColor = new Vector3(0.2296f, 0.2897f, 0.2815f);

    public GameObject Blackbox;


    public float timer;

    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()

    {
        timer = (timer + Time.deltaTime);
        if (ResetCounter == 11)
        {


            if (!LevelScript.stage2)
            {
                LevelScript.stage2 = true;
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
