using UnityEngine.UI;
using UnityEngine;

public class MinigameChoiceAdditionalBehaviour : MonoBehaviour
{

    [SerializeField]
    CurrentLevelReference currentLevelReference;
    [SerializeField]
    CurrentPatientReference currentPatientReference;

    [SerializeField]
    Button rcpButton;
    [SerializeField]
    Button heimlichButton;
    [SerializeField]
    Button burnButton;


    public void CheckIfTutorialAndOnlyShowRightMinigame()
    {
        if(currentLevelReference.Value.IsTutorial)
        {
            Case x = currentPatientReference.Value.PatientCase;
            burnButton.interactable = false;
            heimlichButton.interactable = false;
            rcpButton.interactable = false;

            if (x.burnInLeftHand)
            {
                burnButton.interactable = true;
            }
            else if(x.heartAttack)
            {
                rcpButton.interactable = true;
            }
            else if(x.choking)
            {
                heimlichButton.interactable = true;
            }
            
        }
    }

   
}
