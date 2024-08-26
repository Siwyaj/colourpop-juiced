using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;
using System;
using UnityEditor.Experimental.GraphView;
using System.Linq;

public class ButtonClick : MonoBehaviour
{
    public GameObject Blackbox;

    public Animator animator;

    public GameObject Point;

    public static int Destroycounter;

    public AudioSource audioSource;

    public static Dictionary<Vector3, (bool,DateTime,float)> DestroyedValues = new Dictionary<Vector3, (bool, DateTime,float)>();
    public static Dictionary<Vector3, bool> RemainingPoints = new Dictionary<Vector3, bool>();

    public static List<Vector3> selectedList = new List<Vector3>();
    public static List<Vector3> createdObjects = new List<Vector3>();

    public Vector3 baseColor = new Vector3(0.2296f, 0.2897f, 0.2815f);


    public GameObject game;

    public float elapsedTime;

    public static float pointsSelected;
    public static float PointsMade;


    public GameObject selectedobject;
    Vector3 offset;

    Collider2D targetObject;
    void Start()
    {
        data.selected = null;
        game = GameObject.Find("GameManager");
        audioSource = game.GetComponent<AudioSource>();
        elapsedTime = 0;
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;

        if (LevelScript.stage2)
        {
            Vector3 mouseposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (Input.GetMouseButtonDown(0))
            {
                Collider2D hitCollider = Physics2D.OverlapPoint(mouseposition);

                if (hitCollider != null && hitCollider.CompareTag("Circle")) 
                {
                    targetObject = hitCollider;
                    if (targetObject)
                    {
                        selectedobject = targetObject.transform.gameObject;
                        offset = selectedobject.transform.position - mouseposition;
                    }
                }
                
            }

            if (selectedobject)
            {
                selectedobject.transform.position = mouseposition + offset;
            }

            if(Input.GetMouseButtonUp(0) && selectedobject)
            {
                selectedobject = null;
            }

        }
    }

    void OnMouseDown()
    {
        data.selected = true;
        if (!LevelScript.stage2)
        {
            Point.GetComponent<data>().LogDataForPoint();
            //play pop sound
            audioSource.Play();
            //play pop animation
            animator.SetBool("Pop", true);
            addScore();
            DestroyedValues.Add((Point.GetComponent<data>().xyYCoordinate), (true, DateTime.Now,elapsedTime));
            selectedList.Add(Point.GetComponent<data>().xyYCoordinate);
            createdObjects.Remove(Point.GetComponent<data>().xyYCoordinate);
            elapsedTime = 0;
            //Destroy(gameObject);

        }

       
    }
    private void OnMouseUp()
    {
        data.selected = null;
    }

    void addScore()
    {
        
        Destroycounter ++;
        
    }

   

    //submit button
    public void OnClick()
    {
        data.selected = false;




        Destroycounter = 0;
        
        foreach (var x in SpawnManager.createdPoints)
        {

            (bool, DateTime,float) equal;
            if (!DestroyedValues.TryGetValue(x.Key, out equal))
            {   
                RemainingPoints.Add(x.Key,x.Value);
            }
            
        }





        elapsedTime = 0;
        data.timeSinceLastPress = 0;

        //CreateText();

        //Clears list when submitting 
        DestroyedValues.Clear();
        RemainingPoints.Clear();

        SpawnManager.createdPoints.Clear();
        
        DataManager.ResetCounter += 1;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }


    void CreateText()
    {  
        string path = Application.dataPath + "/CP Juiced Data log.csv";

        if(File.Exists(path))
        {
            File.AppendAllText(path, "\n");
            
            

             string level = DataManager.levelNumber.ToString();

            foreach (var y in DestroyedValues)
        {       

                string destroyedData = " "+ y.Key[0] + " " + y.Key[1]  + " " + y.Value;
                File.AppendAllText(path,destroyedData);
                File.AppendAllText(path, "\n");


            }

            
            File.AppendAllText(path, "\n");

            foreach (var x in RemainingPoints)
        {
            string data =" " + x.Key[0] + " " + x.Key[1] + " " + x.Value;
            File.AppendAllText(path,data);
            File.AppendAllText(path, "\n");

            }
        }
        
        
       
    }



}
