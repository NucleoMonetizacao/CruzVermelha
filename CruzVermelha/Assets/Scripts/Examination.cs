﻿using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Examination : MonoBehaviour
{
    [SerializeField]
    CurrentPatientReference CurrentPatientReference;

    [SerializeField]
    GameObject examinationCompleteIcon;


    [SerializeField]
    Button returnButton;

    [SerializeField]
    Button rightHandPointButton;
    [SerializeField]
    Button leftHandPointButton;
    [SerializeField]
    Button chestPointButton;
    [SerializeField]
    Button headPointButton;
    [SerializeField]
    float examinationCameraSize;
    [SerializeField]
    ControladorCamera controladorCamera;

    [SerializeField]
    GameObject pointInformationGameObject;
    [SerializeField]
    TextMeshProUGUI pointInformationText;


    [SerializeField]
    UnityEvent ExaminationCompleted;

    

    public void BackToDefaultCameraPosition()
    {
        CameraFocus.BackToStartingPositionAndSize();
        returnButton.image.enabled = false;
        pointInformationGameObject.SetActive(false);

    }

    public void SetControladorCameraTo(bool x)
    {
        controladorCamera.enabled = x;
    }

    public void CameraFocusBackToStartingPositionAndSize()
    {
        CameraFocus.BackToStartingPositionAndSize();
    }

    public void SetToExaminationCamera()
    {
        CameraFocus.FocusOnPositionWithSize(Camera.main.transform.localPosition, examinationCameraSize);
    }

    public void SetPointButtons()
    {
        Case x = CurrentPatientReference.Value.PatientCase;

        if(x.examinationComplete)
        {
            examinationCompleteIcon.SetActive(true);
        }
        else
        {
            examinationCompleteIcon.SetActive(false);

        }
        
        


        if (x.chestExamined)
        {
            chestPointButton.image.enabled = false;
            
        }
        else
        {
            chestPointButton.image.enabled  = true;
        }
        if (x.leftHandExamined)
        {
            leftHandPointButton.image.enabled  = false;
        }
        else
        {
            leftHandPointButton.image.enabled  = true;
        }
        if (x.rightHandExamined)
        {
            rightHandPointButton.image.enabled  = false;
        }
        else
        {
            rightHandPointButton.image.enabled = true;
        }
        if (x.headExamined)
        {
            headPointButton.image.enabled = false;
        }
        else
        {
            headPointButton.image.enabled = true;
        }
        
    }

    public void FocusOnPoint(ExaminationPoint x)
    {
        pointInformationGameObject.SetActive(true);
        returnButton.image.enabled = true;
        CameraFocus.FocusOnPositionWithSize(new Vector3(x.cameraPosition.x, x.cameraPosition.y, -10), x.cameraSize);
    }

    public void FocusOnRightHand()
    {
        rightHandPointButton.image.enabled = false;
        Case patientCase = CurrentPatientReference.Value.PatientCase;

       

        patientCase.desiresHelp = true;
        patientCase.bleeding = false;

        patientCase.burn = false;
        pointInformationText.text = "";
        if (patientCase.burnInLeftHand)
        {
            patientCase.burn = true;
            

        }

        patientCase.fractures = false;

        patientCase.rightHandExamined = true;
        CheckIfComplete(patientCase);

    }

    public void FocusOnLeftHand()
    {
        leftHandPointButton.image.enabled = false;
       Case patientCase = CurrentPatientReference.Value.PatientCase;



        patientCase.desiresHelp = true;
        patientCase.bleeding = false;
        pointInformationText.text = "";
        patientCase.burn = false;
        if(patientCase.burnInLeftHand)
        {
            patientCase.burn = true;
            pointInformationText.text = "Queimadura";
        }

        patientCase.fractures = false;

        patientCase.leftHandExamined = true;
        CheckIfComplete(patientCase);
    }

    public void FocusOnChest()
    {
        chestPointButton.image.enabled = false;
        Case patientCase = CurrentPatientReference.Value.PatientCase;



        patientCase.desiresHelp = true;
        patientCase.bleeding = false;
        patientCase.fractures = false;
        pointInformationText.text = "";
        patientCase.breathing = true;
        if(patientCase.heartAttack)
        {
            patientCase.breathing = false;
            pointInformationText.text = "Não está respirando";
        }

        patientCase.chestExamined = true;
        CheckIfComplete(patientCase);
    }

    public void FocusOnHead()
    {
        headPointButton.image.enabled = false;
        Case patientCase = CurrentPatientReference.Value.PatientCase;



        patientCase.desiresHelp = true;
        patientCase.bleeding = false;
        patientCase.fractures = false;
        pointInformationText.text = "";
        patientCase.breathing = true;
        if (patientCase.heartAttack || patientCase.choking)
        {
            pointInformationText.text += "Não respirando";
            patientCase.breathing = false;
        }

        patientCase.conciouss = true;
        if(patientCase.heartAttack)
        {
            patientCase.conciouss = false;
            pointInformationText.text += "\nInconsciente";
        }


        patientCase.headExamined = true;

        CheckIfComplete(patientCase);
   
    }

    void CheckIfComplete(Case patientCase)
    {
        if (patientCase.headExamined && patientCase.leftHandExamined && patientCase.rightHandExamined && patientCase.chestExamined)
        {
            patientCase.examinationComplete = true;
            examinationCompleteIcon.SetActive(true);
            ExaminationCompleted.Invoke();
        }
    }

}
