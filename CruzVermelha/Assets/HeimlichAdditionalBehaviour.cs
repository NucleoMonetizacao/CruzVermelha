using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HeimlichAdditionalBehaviour : MonoBehaviour
{
    [SerializeField]
    MiniGameEngasgo miniGameEngasgo;

    [SerializeField]
    CurrentPatientReference currentPatientReference;

    [SerializeField]
    UnityEvent SucessUnityEvent;
    [SerializeField]
    UnityEvent FailureUnityEvent;

    public void StartListeningToPointerEvents()
    {
        miniGameEngasgo.OnSucess += SucessEventHandler;
        miniGameEngasgo.OnFailure += FailureEventHandler;
    }

    public void StopListeningToPointerEvents()
    {

        miniGameEngasgo.OnSucess -= SucessEventHandler;
        miniGameEngasgo.OnFailure -= FailureEventHandler;
    }

    private void SucessEventHandler()
    {
        SucessUnityEvent.Invoke();
    }

    private void FailureEventHandler()
    {
        FailureUnityEvent.Invoke();
    }

    public void CureChocking()
    {
        Case x = currentPatientReference.Value.PatientCase;
        if (x.choking)
        {
            x.isHealed = true;
            x.choking = false;
            x.breathing = true;
        }
    }

    public void KillPatientIfChoking()
    {
        Case x = currentPatientReference.Value.PatientCase;
        if (x.choking)
        {
            x.isDead = true;
        }
    }
}
