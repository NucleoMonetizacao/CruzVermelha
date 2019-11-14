using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SOSDirector : MonoBehaviour
{
    [SerializeField]
    ScreenDirector screenDirector;
    Case currentCase;


    [SerializeField]
    Button policeButton;

    [SerializeField]
    Button fireDepartmentButton;

    [SerializeField]
    Button ambulanceButton;

    public void SetCaseAndRefreshButtons(Case x)
    {
        currentCase = x;
        SetButtons();
    }

    private void SetButtons()
    {
        if(currentCase.ambulanceCalled)
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
        currentCase.policeCalled = true;
        policeButton.interactable = false;
    }

    public void CallFireDepartment()
    {
        currentCase.fireDepartmentCalled = true;
        fireDepartmentButton.interactable = false;
    }


    public void CallAmbulance()
    {
        
        currentCase.ambulanceCalled = true;
        ambulanceButton.interactable = false;
    }
}
