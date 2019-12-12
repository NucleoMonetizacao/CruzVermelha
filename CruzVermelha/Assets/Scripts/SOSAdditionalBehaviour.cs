using UnityEngine.Events;
using UnityEngine;
using UnityEngine.UI;

public class SOSAdditionalBehaviour : MonoBehaviour
{

    [SerializeField]
    CurrentPatientReference currentPatientReference;
    [SerializeField]
    CurrentLevelReference currentLevelReference;
   


    [SerializeField]
    Button policeButton;

    [SerializeField]
    Button fireDepartmentButton;

    [SerializeField]
    Button ambulanceButton;

    [SerializeField]
    Button nobodyButton;

    [SerializeField]
    UnityEvent helpCalledUnityEvent;





    public void SetButtons()
    {
        Case currentCase = currentPatientReference.Value.PatientCase;

        if (currentCase.ambulanceCalled)
        {
            ambulanceButton.interactable = false;
        }
        else
        {
            ambulanceButton.interactable = true;
        }

        if (currentCase.fireDepartmentCalled)
        {
            fireDepartmentButton.interactable = false;
        }
        else
        {
            fireDepartmentButton.interactable = true;
        }

        if (currentCase.policeCalled)
        {
            policeButton.interactable = false;
        }
        else
        {
            policeButton.interactable = true;
        }


        if (currentCase.nobodyCalled)
        {
            nobodyButton.interactable = false;
        }
        else
        {
            nobodyButton.interactable = true;
        }
        if (currentLevelReference.Value.IsTutorial)
        {
            if (currentCase.burnInLeftHand)
            {
                nobodyButton.interactable = true;
                policeButton.interactable = false;
                fireDepartmentButton.interactable = false;
                ambulanceButton.interactable = false;

            }
            else if (currentCase.heartAttack)
            {
                nobodyButton.interactable = false;
                policeButton.interactable = false;
                fireDepartmentButton.interactable = false;
                ambulanceButton.interactable = true;
            }
            else if (currentCase.choking)
            {
                nobodyButton.interactable = false;
                policeButton.interactable = false;
                fireDepartmentButton.interactable = false;
                ambulanceButton.interactable = true;
            }
        }

    }

    public void PlaySOSCalledSound()
    {
        AudioPlayer.PlaySound(2);
    }


    public void CallPolice()
    {
        Case x = currentPatientReference.Value.PatientCase;
        x.calledHelp = true;
        x.policeCalled = true;
        policeButton.interactable = false;
        helpCalledUnityEvent.Invoke();
    }

    public void CallFireDepartment()
    {
        Case x = currentPatientReference.Value.PatientCase;
        x.calledHelp = true;
        x.fireDepartmentCalled = true;
        fireDepartmentButton.interactable = false;
        helpCalledUnityEvent.Invoke();
    }


    public void CallAmbulance()
    {
        Case x = currentPatientReference.Value.PatientCase;
        x.calledHelp = true;
        x.ambulanceCalled = true;
        ambulanceButton.interactable = false;
        helpCalledUnityEvent.Invoke();
    }

    public void CallNobody()
    {
        Case x = currentPatientReference.Value.PatientCase;
        x.calledHelp = true;
        x.nobodyCalled = true;
        nobodyButton.interactable = false;
        helpCalledUnityEvent.Invoke();
    }
}
