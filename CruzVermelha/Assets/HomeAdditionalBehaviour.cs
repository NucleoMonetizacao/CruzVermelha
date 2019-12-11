
using UnityEngine;
using UnityEngine.UI;

public class HomeAdditionalBehaviour : MonoBehaviour
{
    [SerializeField]
    CurrentPatientReference currentPatientReference;
    [SerializeField]
    Button SOSButton;
    [SerializeField]
    Animator anim;

    public void PlayPhoneUpAnimation()
    {
        anim.Play("PhoneUp");
    }

    public void CheckIfSOSButtonIsInteractable()
    {
        if (currentPatientReference.Value != null)
        {
            if (currentPatientReference.Value.PatientCase.completeClipboardChecked)
            {
                SOSButton.interactable = true;
            }
            else
            {
                SOSButton.interactable = false;
            }
        }
        else
        {
            SOSButton.interactable = false;
        }
    }

    public void PlayHomeSound()
    {
        AudioPlayer.PlaySound(0);
    }
}
