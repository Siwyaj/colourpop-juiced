using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyColors : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        print("Trigger entered" + other);
        if(other.tag == "Circle")
        {
            data.selected = true;
            other.gameObject.GetComponent<data>().LogDataForPoint();
            ButtonClick.selectedList.Add(other.GetComponent<data>().xyYCoordinate);
            SpawnManager.points.Remove(other.gameObject);
            Destroy(other.gameObject);
        }
    }
}
