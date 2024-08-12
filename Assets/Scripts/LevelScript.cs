using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LevelScript : MonoBehaviour
{
    public static bool stage2;

    public GameObject canvas;
    public GameObject selectmenu;
    public AudioSource audioSource;
    public static List<int> levelDonelist = new List<int>();

    public void levelClick(int level)
    {
        DataManager.levelNumber = level;

        Debug.Log(DataManager.levelNumber);

        levelDonelist.Add(level);

        stage2 = false;

        SceneManager.LoadScene("Stage1", LoadSceneMode.Single);
    }

    public void startclick()
    {
        audioSource.Play();
        canvas.SetActive(false);
        selectmenu.SetActive(true);
    }

    public void backtoMain()
    {
        audioSource.Play();
        canvas.SetActive(true);
        selectmenu.SetActive(false);
        
    }

}
