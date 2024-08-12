using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class textScript : MonoBehaviour
{
    public TextMeshProUGUI text;
    public int result;

    // Start is called before the first frame update
    void Start()
    {
        result = Random.Range(70,95);
        text.text = result.ToString() + "%";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
