using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialElement : MonoBehaviour
{
    [SerializeField]
    BoolReference boolToActivate;

    [SerializeField]
    Level levelCondition;
    [SerializeField]
    CurrentLevelReference currentLevelReference;

    [SerializeField]
    bool pauseTimeWhileActive = false;

    public void CheckIfActive()
    {
        bool activate = false;

        if (boolToActivate)
        {
            if (boolToActivate.value == true)
            {
                activate = true; 
            }
            else
            {
                activate = false;
            }
        }
        else
        {
            activate = true;
        }

        if (activate)
        {
            if (levelCondition == null) 
            {
                activate = true;
            }
            else 
            {
                if (levelCondition == currentLevelReference.Value)
                {
                    activate = true;
                }
                else
                {
                    activate = false;
                }
            }
        }

        if (activate)
        {
            Activate();
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    private void Activate()
    {
        
        gameObject.SetActive(true);
        if(pauseTimeWhileActive)
        {
            Time.timeScale = 0f;
            Debug.Log("ue");
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
