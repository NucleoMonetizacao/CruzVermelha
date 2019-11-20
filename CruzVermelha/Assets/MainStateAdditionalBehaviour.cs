using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainStateAdditionalBehaviour : MonoBehaviour
{
    [SerializeField]
    CurrentPatientReference currentPatient;
    [SerializeField]
    Button minigameChoiceButton;

    public void CheckIfCanSelectMiniGame()
    {
        if(currentPatient.Value.PatientCase.completeClipboardChecked && currentPatient.Value.PatientCase.calledHelp)
        {
            minigameChoiceButton.interactable = true;
        }
        else
        {
            minigameChoiceButton.interactable = false;
        }
    }
}
