using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage2Submit : MonoBehaviour
{
    public GameObject blackBox;
    public void Stage2SubmitButton()
    {
        List<Vector3> remainingPointsCoordinates=new List<Vector3>();
        data.selected = false;
        Debug.Log("points count:" + SpawnManager.points.Count);
        foreach(GameObject remainingPoint in SpawnManager.points)
        {



            data.selected = true;
            remainingPoint.GetComponent<data>().LogDataForPoint();
            remainingPointsCoordinates.Add(remainingPoint.GetComponent<data>().xyYCoordinate);
            //Destroy(remainingPoint);
        }



        List<Vector3> endPoints = blackBox.GetComponent<CalculateEndResult>().CalculateEndPoints(ButtonClick.selectedList, remainingPointsCoordinates, DataManager.setBaseColorxyY);
        Debug.Log("endpoints count: " + endPoints.Count);
        foreach(Vector3 point in endPoints)
        {
            Debug.Log(point);
        }
        DataManager.levelResults[DataManager.levelNumber - 1] = endPoints;
        //DataManager.LevelGameObject.GetComponent<GoToLevelScene>().levelScore = remainingPointsCoordinates;
        SceneManager.LoadScene("JespersStartScene", LoadSceneMode.Single);
    }
}
