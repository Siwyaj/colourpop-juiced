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

    public static string Participantnr;
    public static string ParticipantName;

    public static string pathToDataLog;

    // Start is called before the first frame update
    void Start()
    {
        pathToDataLog = Application.dataPath + "/CP Juiced Data log.csv";

        if (!File.Exists(pathToDataLog))
        {
            File.WriteAllText(pathToDataLog, "part.nr;part.name;Date & time;Spawn to Press;Delta time last press;x;y;Y;R(P3);G(P3);B(P3);basex;basey;baseY;baseP3(R);baseP3(G);baseP3(B);Differentiated;Distance to base(xyY);Distance to base(P3);Level.nr;Stage.nr");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Participantnr = ParticipantInput.text.ToString();
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
