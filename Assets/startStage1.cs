using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startStage1 : MonoBehaviour
{
    public void goToStage1()
    {


        SceneManager.LoadScene("Stage1", LoadSceneMode.Single);
        DataManager.levelNumber = 1;

    }
}
