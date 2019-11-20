using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClipboardUI : MonoBehaviour
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

  

    public void SetToCase(CurrentPatientReference currentCaseRerence)
    {
        Case patientCase = currentCaseRerence.Value.PatientCase;

        if (patientCase.examinationComplete)
        {
            patientCase.completeClipboardChecked = true;
        }

        desiresHelpField.SetToValue(patientCase.desiresHelp);
        fractureField.SetToValue(patientCase.fractures);
        burnField.SetToValue(patientCase.burn);
        bleedingField.SetToValue(patientCase.bleeding);
        consciousField.SetToValue(patientCase.conciouss);
        breathingField.SetToValue(patientCase.breathing);

    }
}
