using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DemographScript : MonoBehaviour
{
    //Windows
    public GameObject demographWindow;
    public GameObject confirmWindow;


    //InputFields and buttons
    public TMP_InputField participantNumberField;//number
    public TMP_InputField participantNameField;//name
    public TMP_InputField participantAgeField;//age
    public TMP_InputField participantEyeColorField;//EyeColor
    public TMP_InputField participantCOfBirthField;//Country of birth
    public TMP_InputField participantRecidingCField;//Reciding Contry

    public Button maleButton;
    public Button femaleButton;
    public Button PNTAButton;

    public Button needCorrectionYesButton;
    public Button needCorrectionNoButton;

    public Button nearSightButton;
    public Button farSightButton;
    public Button bothSightButton;//both near and far sighted
    public Button neitherSightButton;//Did not need eye correction

    //Temporary Variables
    string particpantNumberTemp = "Number...";
    string participantNameTemp = "Name...";
    string particpantAgeTemp = "Age...";
    static string particpantSexTemp = "No sex was set...";
    static string needForEyeCorrectionTemp = "No eye correction was set...";
    static string nearFarSightTemp = "No sight type was set...";
    string eyeColorTemp = "Eye color...";
    string countryOfBirthTemp = "Country of birth...";
    string recidingCountryTemp = "Reciding country...";

    
    public void SetValuesFromStatic()
    {
        //Input Fields
        participantNumberField.text = DemographicInfoKeeper.participantNumber;
        participantNameField.text = DemographicInfoKeeper.participantName;
        participantAgeField.text = DemographicInfoKeeper.participantAge;
        participantEyeColorField.text = DemographicInfoKeeper.eyeColor;
        participantCOfBirthField.text = DemographicInfoKeeper.countryOfBirth;
        participantRecidingCField.text = DemographicInfoKeeper.recidingCountry;

        //Buttons
        nearSightButton.interactable = true;
        farSightButton.interactable = true;
        bothSightButton.interactable = true;
        neitherSightButton.interactable = true;
        needCorrectionYesButton.interactable = true;
        needCorrectionNoButton.interactable = true;
        maleButton.interactable = true;
        femaleButton.interactable = true;
        PNTAButton.interactable = true;

        if (DemographicInfoKeeper.participantSex == maleButton.GetComponentInChildren<TMP_Text>().text)
        {
            maleButton.interactable = false;
            particpantSexTemp = DemographicInfoKeeper.participantSex;
        }
        else if (DemographicInfoKeeper.participantSex == femaleButton.GetComponentInChildren<TMP_Text>().text)
        {
            femaleButton.interactable = false;
            particpantSexTemp = DemographicInfoKeeper.participantSex;
        }
        else if (DemographicInfoKeeper.participantSex == PNTAButton.GetComponentInChildren<TMP_Text>().text)
        {
            PNTAButton.interactable = false;
            particpantSexTemp = DemographicInfoKeeper.participantSex;
        }
        else
        {
            particpantSexTemp = "No sex was set...";
        }
        

        if (DemographicInfoKeeper.needForEyeCorrection == needCorrectionYesButton.GetComponentInChildren<TMP_Text>().text)
        {
            needCorrectionYesButton.interactable = false;
            needForEyeCorrectionTemp = DemographicInfoKeeper.needForEyeCorrection;
        }
        else if (DemographicInfoKeeper.needForEyeCorrection == needCorrectionNoButton.GetComponentInChildren<TMP_Text>().text)
        {
            needCorrectionNoButton.interactable = false;
            needForEyeCorrectionTemp = DemographicInfoKeeper.needForEyeCorrection;
        }
        else
        {
            needForEyeCorrectionTemp = "No eye correction was set...";
        }

        switch (DemographicInfoKeeper.nearFarSight)
        {
            case string sight when sight == nearSightButton.GetComponentInChildren<TMP_Text>().text:
                nearSightButton.interactable = false;
                nearFarSightTemp = sight;
                break;

            case string sight when sight == farSightButton.GetComponentInChildren<TMP_Text>().text:
                farSightButton.interactable = false;
                nearFarSightTemp = sight;
                break;

            case string sight when sight == bothSightButton.GetComponentInChildren<TMP_Text>().text:
                bothSightButton.interactable = false;
                nearFarSightTemp = sight;
                break;

            case string sight when sight == neitherSightButton.GetComponentInChildren<TMP_Text>().text:
                neitherSightButton.interactable = false;
                nearFarSightTemp = sight;
                break;

            default:
                nearFarSightTemp = "No sight type was set...";
                break;
        }

    }
    public void EnableDemographWindow()
    {
        demographWindow.SetActive(true);

    }
    public void CancelAndCloseDemographMenu()
    {

        SetValuesFromStatic();

        demographWindow.SetActive(false);
    }
    public void ConfirmChanges()//For base
    {
        confirmWindow.SetActive(true);

    }
    public void TWoFactMakeChanges()//Confirm in 2 fact
    {
        //Load fields into statics
        DemographicInfoKeeper.participantNumber = participantNumberField.text;
        DemographicInfoKeeper.participantName = participantNameField.text;
        DemographicInfoKeeper.participantAge = participantAgeField.text;
        DemographicInfoKeeper.participantSex = particpantSexTemp;
        DemographicInfoKeeper.needForEyeCorrection = needForEyeCorrectionTemp;
        DemographicInfoKeeper.nearFarSight = nearFarSightTemp;
        DemographicInfoKeeper.eyeColor = participantEyeColorField.text;
        DemographicInfoKeeper.countryOfBirth = participantCOfBirthField.text;
        DemographicInfoKeeper.recidingCountry = participantRecidingCField.text;

        DataManager.levelResults = new List<List<Vector3>>() {
        new List<Vector3>(), //level1
        new List<Vector3>(), //level2
        new List<Vector3>(), //level3
        new List<Vector3>(), //level4
        new List<Vector3>(), //level5
        new List<Vector3>(), //level6
        new List<Vector3>(), //level7
        new List<Vector3>(), //level8
        new List<Vector3>(), //level9
        new List<Vector3>(), //level10
        new List<Vector3>(), //level11
        new List<Vector3>(), //level12
        new List<Vector3>(), //level13
        new List<Vector3>(), //level14
        new List<Vector3>(), //level15
        new List<Vector3>(), //level16
        new List<Vector3>(), //level17
        new List<Vector3>(), //level18
        new List<Vector3>(), //level19
        new List<Vector3>(), //level20
        new List<Vector3>(), //level21
        new List<Vector3>(), //level22
        };

        demographWindow.SetActive(false);
        confirmWindow.SetActive(false);

    }
    public void TwoFactCanelMakeChanges()//Confirm in 2 fact
    {
        confirmWindow.SetActive(false);
    }
    public void SexButtonInteraction()
    {
        //Sets all active
        maleButton.interactable = true;
        femaleButton.interactable = true;
        PNTAButton.interactable = true;

        //sets selected inactiove
        GetComponent<Button>().interactable = false;

        //Sets the temporary value to button text
        particpantSexTemp = GetComponentInChildren<TMP_Text>().text;

    }
    public void NeedForEyeCorrectionButtons()
    {
        //Set all active
        needCorrectionYesButton.interactable = true;
        needCorrectionNoButton.interactable = true;

        //sets selected inactiove
        GetComponent<Button>().interactable = false;

        //Sets the temporary value to button text
        needForEyeCorrectionTemp = GetComponentInChildren<TMP_Text>().text; ;
    }
    
    public void EyeSightType()
    {
        //Set all active
        nearSightButton.interactable = true;
        farSightButton.interactable = true;
        bothSightButton.interactable = true;
        neitherSightButton.interactable = true;

        //sets selected inactiove
        GetComponent<Button>().interactable = false;

        //Sets the temporary value to button text
        nearFarSightTemp = GetComponentInChildren<TMP_Text>().text; ;


    }

    public void ResetButton()
    {
        //Reset Static variables in demographkeeper
        DemographicInfoKeeper.ResetDemographVariables();


        //Make all buttons interactable
        nearSightButton.interactable = true;
        farSightButton.interactable = true;
        bothSightButton.interactable = true;
        neitherSightButton.interactable = true;
        needCorrectionYesButton.interactable = true;
        needCorrectionNoButton.interactable = true;
        maleButton.interactable = true;
        femaleButton.interactable = true;
        PNTAButton.interactable = true;

        //Input default text into fields
        participantNumberField.text = "Number...";
        participantNameField.text = "Name...";
        participantAgeField.text = "Age...";
        participantEyeColorField.text = "Eye color...";
        participantCOfBirthField.text = "Country of birth...";
        participantRecidingCField.text = "Reciding country...";
    }
}
