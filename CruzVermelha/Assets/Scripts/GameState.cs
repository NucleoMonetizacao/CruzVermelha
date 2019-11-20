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


    public void StateEnter()
    {
        OnStateEnterUnityEvent.Invoke();
    }

    public void StateExit()
    {
        OnStateExitUnityEvent.Invoke();
    }
}
