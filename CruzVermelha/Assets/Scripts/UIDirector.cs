using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIDirector : MonoBehaviour
{
    [SerializeField]
    ScreenDirector screenDirector;

    [SerializeField]
    GameObject mainScreenRoot;

    [SerializeField]
    GameObject phoneScreenRoot;
    
    [SerializeField]
    GameObject optionsScreenRoot;

    

    private void Start()
    {
        screenDirector.OnGameStateChange += GameStateChangedEvent;
    }


    void GameStateChangedEvent(GameState currentState)
    {
        if(currentState == GameState.Main)
        {
            SetUIToMainScreen();
        }
        else if (currentState == GameState.Options)
        {
            SetUIToOptionsScreen();
        }
        else if (currentState == GameState.Phone)
        {
            SetsUIToPhoneScreen();
        }
    }



    private void SetUIToMainScreen()
    {
        mainScreenRoot.SetActive(true);

        optionsScreenRoot.SetActive(false);
        phoneScreenRoot.SetActive(false);
    }

 

    private void SetUIToOptionsScreen()
    {
        optionsScreenRoot.SetActive(true);

        mainScreenRoot.SetActive(false);
        phoneScreenRoot.SetActive(false);
    }

    private void SetsUIToPhoneScreen()
    {
        
        phoneScreenRoot.SetActive(true);

        mainScreenRoot.SetActive(false);
        optionsScreenRoot.SetActive(false);
    }


}


