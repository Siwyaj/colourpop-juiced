using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSelector : MonoBehaviour
{
    public static int sceneNumber = 0;
    public GameObject mainMenu;
    public GameObject levelScene;
    // Start is called before the first frame update
    void Start()
    {
        if (sceneNumber == 0)
        {
            levelScene.SetActive(false);
            mainMenu.SetActive(true);
        }
        else
        {
            levelScene.SetActive(true);
            mainMenu.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
