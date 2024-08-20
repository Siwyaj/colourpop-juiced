using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectButton : MonoBehaviour
{
    public GameObject LevelSelectCanvas;
    public GameObject MenuCanvas;
    public void GoToLevelSelectButton()
    {
        ScrollAndSnapScript.SetSliderTo1();
        Debug.Log("buttonClick");
        LevelSelectCanvas.SetActive(true);
        MenuCanvas.SetActive(false);
    }
}
