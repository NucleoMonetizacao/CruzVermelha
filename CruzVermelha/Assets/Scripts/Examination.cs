using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Events;
using System.Collections;

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
    [SerializeField]
    float examinationCameraSize;


    [SerializeField]
    UnityEvent ExaminationCompleted;


    private RepetidorFeedbackSonoro _repetidorFeedbackSonoro;



    private void Start()
    {
        _repetidorFeedbackSonoro = FindObjectOfType(typeof(RepetidorFeedbackSonoro)) as RepetidorFeedbackSonoro;
    }

    public void BackToDefaultCameraPosition()
    {
        CameraFocus.BackToStartingPositionAndSize();
        returnButton.enabled = false;
        updatedClipboardIcon.SetActive(false);

    }

    public void SetToExaminationCamera()
    {
        CameraFocus.FocusOnPositionWithSize(Camera.main.transform.position, examinationCameraSize);
    }

    public void SetPointButtons()
    {
        Case x = CurrentPatientReference.Value.PatientCase;
        if(x.chestExamined)
        {
            chestPointButton.enabled = false;
            
        }
        else
        {
            chestPointButton.enabled  = true;
        }
        if (x.leftHandExamined)
        {
            leftHandPointButton.enabled  = false;
        }
        else
        {
            leftHandPointButton.enabled  = true;
        }
        if (x.rightHandExamined)
        {
            rightHandPointButton.enabled  = false;
        }
        else
        {
            rightHandPointButton.enabled = true;
        }
        if (x.headExamined)
        {
            headPointButton.enabled = false;
        }
        else
        {
            headPointButton.enabled = true;
        }
    }

    public void FocusOnPoint(ExaminationPoint x)
    {
        returnButton.enabled = true;
        CameraFocus.FocusOnPositionWithSize(new Vector3(x.cameraPosition.x, x.cameraPosition.y, -10), x.cameraSize);
    }

    public void FocusOnRightHand()
    {
        rightHandPointButton.enabled = false;
        rightHandPointButton.image.enabled = false;
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
        leftHandPointButton.enabled = false;
        leftHandPointButton.image.enabled = false;
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
        chestPointButton.enabled = false;
        chestPointButton.image.enabled = false;
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
        headPointButton.enabled = false;
        headPointButton.image.enabled = false;
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
            ExaminationCompleted.Invoke();

            if (patientCase.choking == true)
            {
                AudioPlayer.PlaySound(3);
                _repetidorFeedbackSonoro.tempoLoop = 4.5f;
                _repetidorFeedbackSonoro.asfixia = true;
            }
            else if(patientCase.heartAttack == true)
            {

                _repetidorFeedbackSonoro.rcp = true;
            }
            else if(patientCase.burnInLeftHand == true)
            {

                _repetidorFeedbackSonoro.queimadura = true;
            }

            _repetidorFeedbackSonoro.diagnosticoCompleto = true;
        }

      
    }

 

}
