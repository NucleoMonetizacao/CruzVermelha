using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniGame : MonoBehaviour
{
    [SerializeField]
    CurrentPatientReference currentPatient;
    [SerializeField]
    Image lifeSlider;

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
            gameObject.SetActive(false);
            currentPatient.Value.PatientCase.heartAttack = false;
        }
    }

}
