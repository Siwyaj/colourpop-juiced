using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

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
            remainingPoint.GetComponent<data>().LogDataForPoint();
            //Destroy(remainingPoint);
        }



        List<Vector3> endPoints = blackBox.GetComponent<CalculateEndResult>().CalculateEndPoints(ButtonClick.selectedList, remainingPointsCoordinates, DataManager.setBaseColorxyY);
        SpawnManager.points.Clear();
        remainingPointsCoordinates.Clear();

        foreach(Vector3 point in endPoints)
        {
            Debug.Log(point);
        }
        DataManager.levelResults[DataManager.levelNumber - 1] = endPoints;
        //DataManager.LevelGameObject.GetComponent<GoToLevelScene>().levelScore = remainingPointsCoordinates;
        LevelScript.stage2 = false;


        string tempPath = Application.dataPath + "/CPTemp.csv";
        string logPath = Application.dataPath + "/CPLog.csv";
        string[] tempLines = File.ReadAllLines(tempPath);

        // Open the log file for appending
        using (StreamWriter logWriter = new StreamWriter(logPath, true)) // 'true' means append mode
        {
            foreach (string line in tempLines)
            {
                // Write each line from temp and add a new line
                logWriter.WriteLine(line);
            }
        }
        // Clear the content of tempPath after appending
        File.WriteAllText(tempPath, string.Empty);

        SceneManager.LoadScene("JespersStartScene", LoadSceneMode.Single);

    }
}
