using UnityEngine.UI;
using UnityEngine;

public class Examination : MonoBehaviour
{
    [SerializeField]
    CurrentPatientReference CurrentPatientReference;

    [SerializeField]
    GameObject examinationCompleteIcon;
    [SerializeField]
    GameObject updatedClipboardIcon;

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

    public void BackToDefaultCameraPosition()
    {
        CameraFocus.BackToStartingPositionAndSize();
        returnButton.interactable = false;
        updatedClipboardIcon.SetActive(false);

    }

    public void SetPointButtons()
    {
        Case x = CurrentPatientReference.Value.PatientCase;
        if(x.chestExamined)
        {
            chestPointButton.interactable = false;
        }
        else
        {
            chestPointButton.interactable = true;
        }
        if (x.leftHandExamined)
        {
            leftHandPointButton.interactable = false;
        }
        else
        {
            leftHandPointButton.interactable = true;
        }
        if (x.rightHandExamined)
        {
            rightHandPointButton.interactable = false;
        }
        else
        {
            rightHandPointButton.interactable = true;
        }
        if (x.headExamined)
        {
            headPointButton.interactable = false;
        }
        else
        {
            headPointButton.interactable = true;
        }
    }

    public void FocusOnPoint(ExaminationPoint x)
    {
        returnButton.interactable = true;
        CameraFocus.FocusOnPositionWithSize(new Vector3(x.cameraPosition.x, x.cameraPosition.y, -10), x.cameraSize);
    }

    public void FocusOnRightHand()
    {
        rightHandPointButton.interactable = false;
        Case patientCase = CurrentPatientReference.Value.PatientCase;

        if(!patientCase.rightHandExamined)
        {
            updatedClipboardIcon.SetActive(true);
        }

        patientCase.desiresHelp = true;
        patientCase.bleeding = false;

        patientCase.burn = false;
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
        leftHandPointButton.interactable = false;
        Case patientCase = CurrentPatientReference.Value.PatientCase;

        if (!patientCase.leftHandExamined)
        {
            updatedClipboardIcon.SetActive(true);
        }

        patientCase.desiresHelp = true;
        patientCase.bleeding = false;

        patientCase.burn = false;
        if(patientCase.burnInLeftHand)
        {
            patientCase.burn = true;
        }

        patientCase.fractures = false;

        patientCase.leftHandExamined = true;
        CheckIfComplete(patientCase);
    }

    public void FocusOnChest()
    {
        chestPointButton.interactable = false;
        Case patientCase = CurrentPatientReference.Value.PatientCase;

        if (!patientCase.chestExamined)
        {
            updatedClipboardIcon.SetActive(true);
        }

        patientCase.desiresHelp = true;
        patientCase.bleeding = false;
        patientCase.fractures = false;

        patientCase.breathing = true;
        if(patientCase.heartAttack)
        {
            patientCase.breathing = false;
        }

        patientCase.chestExamined = true;
        CheckIfComplete(patientCase);
    }

    public void FocusOnHead()
    {
        headPointButton.interactable = false;
        Case patientCase = CurrentPatientReference.Value.PatientCase;

        if (!patientCase.headExamined)
        {
            updatedClipboardIcon.SetActive(true);
        }

        patientCase.desiresHelp = true;
        patientCase.bleeding = false;
        patientCase.fractures = false;

        patientCase.breathing = true;
        if (patientCase.heartAttack || patientCase.choking)
        {
            patientCase.breathing = false;
        }

        patientCase.conciouss = true;
        if(patientCase.heartAttack)
        {
            patientCase.conciouss = false;
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
        }
    }

}
