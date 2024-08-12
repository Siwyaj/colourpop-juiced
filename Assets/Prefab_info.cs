using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prefab_info : MonoBehaviour
{
    public Vector3 xyYCoordinate;
    public Color P3Color;
    public float xyYDistanceToBasexyY;
    public float P3ColorDistanceToBase;


    private void OnDestroy()
    {
        Debug.Log("Color: " + xyYCoordinate*10 + " was destroyed, logging data...");
    }


}