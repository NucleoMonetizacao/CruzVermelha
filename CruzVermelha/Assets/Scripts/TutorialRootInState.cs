using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialRootInState : MonoBehaviour
{
    [SerializeField]
    List<TutorialElement> tutorialElements;

    public void CheckTutorialElements()
    {
        foreach(TutorialElement x in tutorialElements)
        {
            x.CheckIfActive();
        }

    }

    public void RemoveFromTutorialElementsList(TutorialElement x)
    {
        tutorialElements.Remove(x);
    }
 
}
