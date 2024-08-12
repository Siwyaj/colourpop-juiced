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
            Destroy(other.gameObject);
        }
    }
}
