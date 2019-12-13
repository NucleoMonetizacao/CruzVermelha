using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ClipboardAdditionalBehaviour : MonoBehaviour
{
    [SerializeField]
    ClipboardField breathingField;

    [SerializeField]
    ClipboardField consciousField;

    [SerializeField]
    ClipboardField bleedingField;

    [SerializeField]
    ClipboardField burnField;

    [SerializeField]
    ClipboardField desiresHelpField;

    [SerializeField]
    ClipboardField fractureField;

    public UnityEvent CompleteClipboardChecked;

  

    public void SetToCase(CurrentPatientReference currentCaseRerence)
    {
        Case patientCase = currentCaseRerence.Value.PatientCase;

        if (patientCase.examinationComplete)
        {
            patientCase.completeClipboardChecked = true;
            CompleteClipboardChecked.Invoke();
        }

        desiresHelpField.SetToValue(patientCase.desiresHelp);
        fractureField.SetToValue(patientCase.fractures);
        burnField.SetToValue(patientCase.burn);
        bleedingField.SetToValue(patientCase.bleeding);
        consciousField.SetToValue(patientCase.conciouss);
        breathingField.SetToValue(patientCase.breathing);

    }
}
