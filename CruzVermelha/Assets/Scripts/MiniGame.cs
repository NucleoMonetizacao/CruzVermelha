using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniGame : MonoBehaviour
{
    Patient currentPatient;
    [SerializeField]
    Image lifeSlider;

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
            currentPatient = x;
        }
    }

    public void Update() //deletar depois
    {
        if(lifeSlider.fillAmount > 0.98)
        {
            gameObject.SetActive(false);
            currentPatient.gameObject.SetActive(true);
            currentPatient.PatientCase.heartAttack = false;
        }
    }

}
