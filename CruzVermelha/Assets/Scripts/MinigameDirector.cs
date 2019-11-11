using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameDirector : MonoBehaviour
{
    Patient currentPatient;
    public Patient CurrentPatient { get => currentPatient; }

    [SerializeField]
    GameObject testMinigameRoot;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(0.5f);
        foreach(Patient x in FindObjectsOfType<Patient>())
        {
            x.OnSelected += PatientSelectedEvent;
        }
    }

    void PatientSelectedEvent(Patient selectedPatient)
    {
        StartMinigame(selectedPatient);
    }

    public void StartMinigame(Patient patient)
    {
        currentPatient = patient;
        testMinigameRoot.SetActive(true);

    }
    
}
