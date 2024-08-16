using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class demographicMenu : MonoBehaviour
{
    public GameObject demographicMenuParent;
    public GameObject demographicMenuOpenButton;

    public void EnableDemographicMenu()
    {
        demographicMenuParent.SetActive(true);
        demographicMenuOpenButton.SetActive(false);

    }
}
