using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneScreenDirector : MonoBehaviour
{
    [SerializeField]
    OverviewScreenDirector overviewScreenDirector;

    PhoneStates currentPhoneState;

    [SerializeField]
    GameObject MainPhoneScreen;

    [SerializeField]
    GameObject ClipboardPhoneScreen;
    [SerializeField]
    ClipboardUI ClipboardDirector;



    [SerializeField]
    GameObject SOSPhoneScreen;
    [SerializeField]
    SOSDirector SOSDirector;

    // Start is called before the first frame update
    void Start()
    {
        SetPhoneStateToMain();
    }

    private void OnDisable()
    {
        SetPhoneStateToMain();
    }

    /*void SetPhoneStateTo(PhoneStates newState)
    {


    }
    */


    public void SetPhoneStateToMain()
    {
        currentPhoneState = PhoneStates.Main;
        MainPhoneScreen.SetActive(true);
        ClipboardPhoneScreen.SetActive(false);
        SOSPhoneScreen.SetActive(false);
    }

    public void SetPhoneStateToClipboard()
    {
        //ClipboardDirector.SetToCase(overviewScreenDirector.CurrentPatient.PatientCase);
        currentPhoneState = PhoneStates.Clipboard;
        MainPhoneScreen.SetActive(false);
        ClipboardPhoneScreen.SetActive(true);
        SOSPhoneScreen.SetActive(false);
        
    }

    public void SetPhoneStateToSOS()
    {
        currentPhoneState = PhoneStates.SOS;
        MainPhoneScreen.SetActive(false);
        ClipboardPhoneScreen.SetActive(false);
        SOSPhoneScreen.SetActive(true);

      
    }

    public enum PhoneStates
    {
        Main, Clipboard, SOS
    }


}
