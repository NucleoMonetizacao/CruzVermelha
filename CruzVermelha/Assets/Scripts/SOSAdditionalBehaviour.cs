using UnityEngine.Events;
using UnityEngine;
using UnityEngine.UI;

public class SOSAdditionalBehaviour : MonoBehaviour
{

    [SerializeField]
    CurrentPatientReference currentPatientReference;
   


    [SerializeField]
    Button policeButton;

    [SerializeField]
    Button fireDepartmentButton;

    [SerializeField]
    Button ambulanceButton;

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
}
