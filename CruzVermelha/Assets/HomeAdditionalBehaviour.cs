
using UnityEngine;
using UnityEngine.UI;

public class HomeAdditionalBehaviour : MonoBehaviour
{
    [SerializeField]
    CurrentPatientReference currentPatientReference;
    [SerializeField]
    CurrentLevelReference currentLevelReference;
    [SerializeField]
    Button SOSButton;
    [SerializeField]
    Animator anim;

    public void StateEnter()
    {
        CheckIfSOSButtonIsInteractable();
        PlayHomeSound();
    }

    public void PlayPhoneUpAnimation()
    {
        anim.Play("PhoneUp");
    }

    private void CheckIfSOSButtonIsInteractable()
    {
        if (currentPatientReference.Value != null)
        {
            if (currentPatientReference.Value.PatientCase.completeClipboardChecked || !currentLevelReference.Value.IsTutorial)
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

    private void PlayHomeSound()
    {
        AudioPlayer.PlaySound(0);
    }
}
