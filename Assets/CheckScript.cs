using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class CheckScript : MonoBehaviour
{
    public int levelID;
    public Image image;
    public GameObject resultFrame;
    public AudioSource audioSource;


    // Start is called before the first frame update
    async void Start()
    {
        if(ButtonClick.pointsSelected > 0)
        {
             resultFrame.SetActive(true);
             ButtonClick.pointsSelected = 0;
             ButtonClick.PointsMade = 0;
             await Task.Delay(2000);
             resultFrame.SetActive(false);
        }
       

        if(LevelScript.levelDonelist.Contains(levelID))
        {
           image.GetComponent<Image>().color = Color.green;
           audioSource.Play();
           
        }

        
    }

}
