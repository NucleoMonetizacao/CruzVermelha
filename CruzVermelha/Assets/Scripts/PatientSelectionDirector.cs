using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientSelectionDirector : MonoBehaviour
{
    Patient currentPatient;
    public Patient CurrentPatient { get => currentPatient; }

    [SerializeField]
    PatientClipboard patientClipboard;

    [SerializeField]
    GameObject scenaryLookRoot;



    void PatientSelectedEvent(Patient selectedPatient)
    {
        currentPatient = selectedPatient;
        patientClipboard.ActivateAndSetToPatientCase(currentPatient);
        gameObject.SetActive(true);
        scenaryLookRoot.SetActive(false);

    }

    public void UnselectPatient()
    {
        currentPatient = null;
        gameObject.SetActive(false);
        scenaryLookRoot.SetActive(true);
    }

    public void NewPatientInstantiated(Patient newPatient)
    {
        newPatient.OnSelected += PatientSelectedEvent;
    }




}
