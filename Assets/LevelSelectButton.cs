using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectButton : MonoBehaviour
{
    public GameObject LevelSelectCanvas;
    public GameObject MenuCanvas;
    public void GoToLevelSelectButton()
    {
        LevelSelectCanvas.SetActive(true);
        MenuCanvas.SetActive(false);
        ScrollAndSnapScript.SetSliderTo1();
    }
}
