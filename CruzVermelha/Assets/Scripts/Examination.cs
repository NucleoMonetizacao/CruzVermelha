using UnityEngine.UI;
using UnityEngine;

public class Examination : MonoBehaviour
{
    [SerializeField]
    CurrentPatientReference CurrentPatientReference;

    [SerializeField]
    GameObject examinationCompleteIcon;

    [SerializeField]
    Button returnButton;

    public void BackToDefaultCameraPosition()
    {
        CameraFocus.BackToStartingPositionAndSize();
        returnButton.interactable = false;

    }

    public void FocusOnPoint(ExaminationPoint x)
    {
        returnButton.interactable = true;
        CameraFocus.FocusOnPositionWithSize(new Vector3(x.cameraPosition.x, x.cameraPosition.y, -10), x.cameraSize);
    }

    public void FocusOnRightHand()
    {
        Case patientCase = CurrentPatientReference.Value.PatientCase;

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
        Case patientCase = CurrentPatientReference.Value.PatientCase;

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
        Case patientCase = CurrentPatientReference.Value.PatientCase;

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
        Case patientCase = CurrentPatientReference.Value.PatientCase;

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

        patientCase.burn = false;

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
