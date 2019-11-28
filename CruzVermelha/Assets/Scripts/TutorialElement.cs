using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialElement : MonoBehaviour
{
    [SerializeField]
    BoolReference boolToActivate;

    [SerializeField]
    bool pauseTimeWhileActive = false;

    public void CheckIfActive()
    {
            if (boolToActivate)
            {
                if (boolToActivate.value == true)
                {
                    Activate();
                }
                else
                {
                    gameObject.SetActive(false);
                }
            }
            else
            {
                Activate();
            }
    }

    private void Activate()
    {
        gameObject.SetActive(true);
        if(pauseTimeWhileActive)
        {
            Time.timeScale = 0f;
        }
    }

    public void OkButtonPressed()
    {
        if(pauseTimeWhileActive)
        {
            Time.timeScale = 1f;
        }
        transform.parent.gameObject.GetComponent<TutorialRootInState>().RemoveFromTutorialElementsList(this);
        Destroy(gameObject);
    }

}
