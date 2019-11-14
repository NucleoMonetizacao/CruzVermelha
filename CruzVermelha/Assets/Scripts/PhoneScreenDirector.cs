using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneScreenDirector : MonoBehaviour
{
    PhoneStates currentPhoneState;

    [SerializeField]
    GameObject MainPhoneScreen;

    [SerializeField]
    GameObject ClipboardPhoneScreen;

    [SerializeField]
    GameObject SOSPhoneScreen;

    // Start is called before the first frame update
    void Start()
    {
        SetPhoneStateToMain();
    }

    private void OnDisable()
    {
        
    }

    /*
    void SetPhoneStateTo(PhoneStates newState)
    {


    }
    */

    private void SetPhoneStateToMain()
    {
        
    }

    public enum PhoneStates
    {
        Main, Clipboard, SOS
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
