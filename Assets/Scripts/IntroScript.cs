using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using TMPro;

public class IntroScript : MonoBehaviour
{
    public GameObject canvas;
    public GameObject intropart1;
    public GameObject intropart2;
    public AudioSource audioSource;
    public TMP_InputField ParticipantInput;

    public static string Participant;

    // Start is called before the first frame update
    void Start()
    {
        string path = Application.dataPath + "/CP Juiced Data log.csv";

        if (!File.Exists(path))
        {
            File.WriteAllText(path, "ParticipantNumber x y True/false Time/Date DeltaTime" );
        }

        if (File.Exists(path))
        {
            File.AppendAllText(path, "\n");
            File.AppendAllText(path, "new participant");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Participant = ParticipantInput.text.ToString();
    }

    public void OnClickintro()
    {
        canvas.SetActive(false);
        intropart1.SetActive(true);
        audioSource.Play();
    }

    public void OnclickIntro1()
    {
        intropart1.SetActive(false);
        intropart2.SetActive(true);
        audioSource.Play();
    }

    public void OnclickIntro2()
    {
        intropart2.SetActive(false);
        canvas.SetActive(true);
        audioSource.Play();
    }
}
