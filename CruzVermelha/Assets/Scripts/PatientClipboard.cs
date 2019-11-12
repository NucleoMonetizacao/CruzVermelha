using TMPro;
using UnityEngine;

public class PatientClipboard : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI clipboardText;

    public void ActivateAndSetToPatientCase(Patient patient)
    {
        Case patientCase = patient.PatientCase;
        clipboardText.text = "";
        if(patientCase.burnInLeftHand)
        {
            clipboardText.text += "Queimadura na mão esquerda\n";
        }
        if(patientCase.heartAttack)
        {
            clipboardText.text += "Tendo um ataque cardiaco\n";
        }
        if(patientCase.choking)
        {
            clipboardText.text += "Engasgando\n";
        }
        gameObject.SetActive(true);
    }
}
