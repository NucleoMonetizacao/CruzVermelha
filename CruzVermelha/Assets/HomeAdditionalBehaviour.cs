using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeAdditionalBehaviour : MonoBehaviour
{
    [SerializeField]
    CurrentPatientReference currentPatientReference;
    [SerializeField]
    Button SOSButton;

    public void CheckIfSOSButtonIsInteractable()
    {
        if(currentPatientReference.Value.PatientCase.completeClipboardChecked)
        {
            SOSButton.interactable = true;
        }
        else
        {
            SOSButton.interactable = false;
        }
    }
}
