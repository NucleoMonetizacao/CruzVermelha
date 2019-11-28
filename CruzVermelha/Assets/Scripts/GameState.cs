using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Scripts.Utility.HierarchyHighlighter))]
public class GameState : MonoBehaviour
{
    [SerializeField]
    UnityEvent OnStateEnterUnityEvent;

    [SerializeField]
    UnityEvent OnStateExitUnityEvent;

    [SerializeField]
    TutorialRootInState tutorialRootInState;




    public void StateEnter()
    {
        OnStateEnterUnityEvent.Invoke();
        if(tutorialRootInState && tutorialRootInState.gameObject.activeSelf)
        {
            tutorialRootInState.CheckTutorialElements();
        }
    }

    public void StateExit()
    {
        OnStateExitUnityEvent.Invoke();
    }
}
