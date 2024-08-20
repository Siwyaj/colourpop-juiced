using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialButtons : MonoBehaviour
{

    public GameObject currentCanvas;
    public GameObject canvasToGoTO;



    public void ClickToGotoNextCanvas()
    {
        Debug.Log("Button was pressed");
        currentCanvas.SetActive(false);
        canvasToGoTO.SetActive(true);

    }


}
