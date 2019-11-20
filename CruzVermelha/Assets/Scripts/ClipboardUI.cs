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
        desiresHelpField.SetToValue(true);
        fractureField.SetToValue(false);
        if(patientCase.heartAttack)
        {
            fractureField.SetToValue(false);
            burnField.SetToValue(false);
            bleedingField.SetToValue(false);
            consciousField.SetToValue(false);
            breathingField.SetToValue(true);
        }
        else
        {
            fractureField.SetToValue(false);
            burnField.SetToValue(false);
            bleedingField.SetToValue(false);
            consciousField.SetToValue(true);
            breathingField.SetToValue(true);
        }
    }
}
