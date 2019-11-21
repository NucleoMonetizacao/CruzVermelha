using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainStateAdditionalBehaviour : MonoBehaviour
{
    [SerializeField]
    CurrentPatientReference currentPatientReference;
    [SerializeField]
    Button minigameChoiceButton;
    [SerializeField]
    GameObject levelCompleteGameObject;
    [SerializeField]
    GameObject levelFailedGameObject;

    public void CheckIfCanSelectMiniGame()
    {
        if(currentPatientReference.Value.PatientCase.completeClipboardChecked && currentPatientReference.Value.PatientCase.calledHelp)
        {
            minigameChoiceButton.interactable = true;
        }
        else
        {
            minigameChoiceButton.interactable = false;
        }
    }

    public void CheckIfLevelIsComplete()
    {
        Case x = currentPatientReference.Value.PatientCase;
        if(x.heartAttack == false && x.choking == false && x.burnInLeftHand == false)
        {
            levelCompleteGameObject.SetActive(true);
        }
    }

    public void CheckIfLevelIsFailed()
    {
        Case x = currentPatientReference.Value.PatientCase;
        if (x.isDead)
        {
            levelFailedGameObject.SetActive(true);
        }
    }
}
