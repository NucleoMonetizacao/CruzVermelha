using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMinigame : MonoBehaviour
{
    [SerializeField]
    MinigameDirector MinigameDirector;



    public void CureHeartAttack()
    {
        MinigameDirector.CurrentPatient.PatientCase.heartAttack = false;
        gameObject.SetActive(false);
    }

    public void CureBurn()
    {
        MinigameDirector.CurrentPatient.PatientCase.burnInLeftHand = false;
        gameObject.SetActive(false);
    }

    public void CureChocking()
    {
        MinigameDirector.CurrentPatient.PatientCase.choking = false;
        gameObject.SetActive(false);
    }
}
