using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SOSDirector : MonoBehaviour
{

    [SerializeField]
    CurrentPatientReference currentPatientReference;
   


    [SerializeField]
    Button policeButton;

    [SerializeField]
    Button fireDepartmentButton;

    [SerializeField]
    Button ambulanceButton;



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


    public void CallPolice()
    {
        Case x = currentPatientReference.Value.PatientCase;
        x.calledHelp = true;
        x.policeCalled = true;
        policeButton.interactable = false;
    }

    public void CallFireDepartment()
    {
        Case x = currentPatientReference.Value.PatientCase;
        x.calledHelp = true;
        x.fireDepartmentCalled = true;
        fireDepartmentButton.interactable = false;
    }


    public void CallAmbulance()
    {
        Case x = currentPatientReference.Value.PatientCase;
        x.calledHelp = true;
        x.ambulanceCalled = true;
        ambulanceButton.interactable = false;
    }
}
