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


    [SerializeField]
    Animator phoneDownAnimator;

    [SerializeField]
    GameObject healedGameObject;

    public void PutPhoneDownAnimation()
    {
        phoneDownAnimator.Play("PutPhoneDown");
    }

    public void CheckIfHealed()
    {
        if (currentPatientReference.Value != null)
        {
            if (currentPatientReference.Value.PatientCase.isHealed)
            {
                healedGameObject.SetActive(true);
            }
            else
            {
                healedGameObject.SetActive(false);
            }
        }
        else
        {
            healedGameObject.SetActive(false);
        }
    }
    
    public void CheckIfCanSelectMiniGame()
    {
        if (currentPatientReference.Value != null)
        {
        
            Case currentPatientCase = currentPatientReference.Value.PatientCase;

            if (!currentPatientCase.isHealed)
            {
                if (currentPatientCase.completeClipboardChecked && currentPatientCase.calledHelp)
                {
                    minigameChoiceButton.gameObject.SetActive(true);
                }
                else
                {
                    minigameChoiceButton.gameObject.SetActive(false);
                }
            }
            else
            {
                minigameChoiceButton.gameObject.SetActive(false);
            }
        }
        else
        {
            minigameChoiceButton.gameObject.SetActive(false);
        }
    }

    public void CheckIfLevelIsComplete()
    {
        bool allPatientsHealed = true;
        Patient[] patientsInScene = FindObjectsOfType<Patient>();
        for (int i = 0; i < patientsInScene.Length; i++)
        {
            if(patientsInScene[i].PatientCase.isHealed == false)
            {
                allPatientsHealed = false;
            }
        }
        if(allPatientsHealed)
        { 
            levelCompleteGameObject.SetActive(true);
        }
    }

    public void CheckIfLevelIsFailed()
    {
        bool onePatientDead = false;
        Patient[] patientsInScene = FindObjectsOfType<Patient>();
        for (int i = 0; i < patientsInScene.Length; i++)
        {
            if (patientsInScene[i].PatientCase.isDead)
            {
                onePatientDead = true;
            }
        }
        if (onePatientDead)
        {
            levelFailedGameObject.SetActive(true);
        }
    }
}
