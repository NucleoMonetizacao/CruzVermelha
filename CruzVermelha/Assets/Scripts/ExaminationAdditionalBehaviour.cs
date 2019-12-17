using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class ExaminationAdditionalBehaviour : MonoBehaviour
{
    [SerializeField]
    CurrentPatientReference currentPatientReference;
    [SerializeField]
    CurrentLevelReference currentLevelReference;

    Case currentCase;

    [SerializeField]
    GameObject examinationCompleteIcon;


    [SerializeField]
    Button returnButton;
    [SerializeField]
    GameObject finishExaminationButtonGameObject;

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


    private RepetidorFeedbackSonoro _repetidorFeedbackSonoro;
    private SetasManager _SetasManager;

    

    public void StateEnter()
    {
        currentCase = currentPatientReference.Value.PatientCase;

        SetTutorialPoints();
        if (currentLevelReference.Value.IsTutorial)
        {
            SetExaminationCompleteIcon();
        }
        else
        {
            currentPatientReference.Value.PatientCase.examinationComplete = true;
            examinationCompleteIcon.SetActive(false);
        }
        DisableAllExaminationPointsButtonImage();
        SetPointButtons();
    
      

        SetToExaminationCamera();
    }

    void SetTutorialPoints()
    {
        if(currentLevelReference.Value.IsTutorial)
        {
            
            

            if(!currentCase.examinationComplete)
            {
                finishExaminationButtonGameObject.SetActive(false);
                if (currentCase.burnInLeftHand)
                {
                    currentCase.rightHandExamined = true;
                    currentCase.headExamined = true;
                    currentCase.chestExamined = true;
                    currentCase.breathing = true;
                    currentCase.conciouss = true;
                    
                }
                else if(currentCase.heartAttack)
                {
                    currentCase.leftHandExamined = true;
                    currentCase.rightHandExamined = true;
                    currentCase.burn = false;
                    currentCase.breathing = true;
                    currentCase.conciouss = true;
                }
                else if(currentCase.choking)
                {
                    currentCase.chestExamined = true;
                    currentCase.leftHandExamined = true;
                    currentCase.rightHandExamined = true;
                    currentCase.burn = false;
                }
            }
            else
            {
                finishExaminationButtonGameObject.SetActive(true);
            }
        }
    }

    private void Start()
    {
        _repetidorFeedbackSonoro = FindObjectOfType(typeof(RepetidorFeedbackSonoro)) as RepetidorFeedbackSonoro;
        _SetasManager = FindObjectOfType(typeof(SetasManager)) as SetasManager;
    }

    public void BackToDefaultCameraPosition()
    {
        Invoke("SetPointButtons", 0.5f);
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

    void SetExaminationCompleteIcon()
    {
        if (currentCase.examinationComplete && currentLevelReference.Value.IsTutorial)
        {
            examinationCompleteIcon.SetActive(true);
        }
        else
        {
            examinationCompleteIcon.SetActive(false);

        }
    }

    public void SetPointButtons()
    {



        if (currentCase.chestExamined)
        {
            chestPointButton.image.enabled = false;
            
        }
        else
        {
            chestPointButton.image.enabled  = true;
        }
        if (currentCase.leftHandExamined)
        {
            leftHandPointButton.image.enabled  = false;
        }
        else
        {
            leftHandPointButton.image.enabled  = true;
        }
        if (currentCase.rightHandExamined)
        {
            rightHandPointButton.image.enabled  = false;
        }
        else
        {
            rightHandPointButton.image.enabled = true;
        }
        if (currentCase.headExamined)
        {
            headPointButton.image.enabled = false;
        }
        else
        {
            headPointButton.image.enabled = true;
        }
        
    }

    private void DisableAllExaminationPointsButtonImage()
    {
        rightHandPointButton.image.enabled = false;
        leftHandPointButton.image.enabled = false;
        headPointButton.image.enabled = false;
        chestPointButton.image.enabled = false;
    }

  

    public void FocusOnPoint(ExaminationPoint x)
    {
        DisableAllExaminationPointsButtonImage();
        pointInformationGameObject.SetActive(true);
        returnButton.image.enabled = true;
        CameraFocus.FocusOnPositionWithSize(new Vector3(x.cameraPosition.x, x.cameraPosition.y, -10), x.cameraSize);
    }

    public void FocusOnRightHand()
    {
        rightHandPointButton.image.enabled = false;

       

        currentCase.desiresHelp = true;
        currentCase.bleeding = false;

        currentCase.burn = false;
        pointInformationText.text = "";
        if (currentCase.burnInLeftHand)
        {
            currentCase.burn = true;
            

        }

        currentCase.fractures = false;

        currentCase.rightHandExamined = true;
        CheckIfComplete(currentCase);

    }

    public void FocusOnLeftHand()
    {
        leftHandPointButton.image.enabled = false;



        currentCase.desiresHelp = true;
        currentCase.bleeding = false;
        pointInformationText.text = "";
        currentCase.burn = false;
        if(currentCase.burnInLeftHand)
        {
            currentCase.burn = true;
            pointInformationText.text = "Queimadura";
        }

        currentCase.fractures = false;

        currentCase.leftHandExamined = true;
        CheckIfComplete(currentCase);
    }

    public void FocusOnChest()
    {
        chestPointButton.image.enabled = false;




        currentCase.desiresHelp = true;
        currentCase.bleeding = false;
        currentCase.fractures = false;
        pointInformationText.text = "";
        currentCase.breathing = true;
        if(currentCase.heartAttack)
        {
            currentCase.breathing = false;
            pointInformationText.text = "Não está respirando";
        }

        currentCase.chestExamined = true;
        CheckIfComplete(currentCase);
    }

    public void FocusOnHead()
    {
        headPointButton.image.enabled = false;
     



        currentCase.desiresHelp = true;
        currentCase.bleeding = false;
        currentCase.fractures = false;
        pointInformationText.text = "";
        currentCase.breathing = true;
        if (currentCase.heartAttack || currentCase.choking)
        {
            pointInformationText.text += "Não respirando";
            currentCase.breathing = false;
        }

        currentCase.conciouss = true;
        if(currentCase.heartAttack)
        {
            currentCase.conciouss = false;
            pointInformationText.text += "\nInconsciente";
        }


        currentCase.headExamined = true;

        CheckIfComplete(currentCase);
   
    }

    void CheckIfComplete(Case patientCase)
    {
        if (patientCase.headExamined && patientCase.leftHandExamined && patientCase.rightHandExamined && patientCase.chestExamined)
        {
            if(currentLevelReference.Value.IsTutorial)
            {
                finishExaminationButtonGameObject.SetActive(true);
                examinationCompleteIcon.SetActive(true);
            }
            else
            {
                examinationCompleteIcon.SetActive(false);
            }

            patientCase.examinationComplete = true;
            
            ExaminationCompleted.Invoke();
            _SetasManager.AtivaSeta = true;

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
