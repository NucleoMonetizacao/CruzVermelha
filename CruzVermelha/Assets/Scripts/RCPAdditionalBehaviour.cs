using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class RCPAdditionalBehaviour : MonoBehaviour
{
    [SerializeField]
    CurrentPatientReference currentPatient;
    [SerializeField]
    Image lifeSlider;

    [SerializeField]
    UnityEvent sucessUnityEvent;
    [SerializeField]
    UnityEvent failureUnityEvent;
    [SerializeField]
    UnityEvent wrongChoiceUnityEvent;

    public void DisablePatient()
    {
        currentPatient.Value.gameObject.SetActive(false);
    }

    public void EnablePatient()
    {
        currentPatient.Value.gameObject.SetActive(true);
    }

    public void PatientInstanciated(Patient x)
    {
        x.OnSelected += StartMinigame;

    }

    private void StartMinigame(Patient x)
    {
        if (lifeSlider.fillAmount < 0.8)
        {
            gameObject.SetActive(true);
            x.gameObject.SetActive(false);
        }
    }

    public void Update() //deletar depois
    {
        if(lifeSlider.fillAmount > 0.98)
        {
            if (currentPatient.Value.PatientCase.heartAttack)
            {
                sucessUnityEvent.Invoke();
            }
            else
            {
                wrongChoiceUnityEvent.Invoke();
            }
        }
        else if (lifeSlider.fillAmount < 0.01)
        {
            if (currentPatient.Value.PatientCase.heartAttack)
            {
                failureUnityEvent.Invoke();
            }
            else
            {
                wrongChoiceUnityEvent.Invoke();
            }
           
        }
    }

    public void CurePatientHeartAttack()
    {
        Case x = currentPatient.Value.PatientCase;
        if (x.heartAttack)
        {
            currentPatient.Value.PatientCase.isHealed = true;
            currentPatient.Value.PatientCase.heartAttack = false;
            currentPatient.Value.PatientCase.conciouss = true;
            currentPatient.Value.PatientCase.breathing = true;
        }
    }

    public void KillPatientIfHeartAttack()
    {
        Case x = currentPatient.Value.PatientCase;
       
        if(x.heartAttack)
        {

            x.isDead = true;

        }
    }

}
