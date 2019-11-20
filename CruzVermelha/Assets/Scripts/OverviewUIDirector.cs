using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Scripts.Utility.HierarchyHighlighter))]
public class OverviewUIDirector : MonoBehaviour
{
    [SerializeField]
    OverviewScreenDirector overviewScreenDirector;

    [SerializeField]
    GameObject mainScreenRoot;

    [SerializeField]
    GameObject phoneScreenRoot;
    
    [SerializeField]
    GameObject optionsScreenRoot;

    

    private void Start()
    {
        overviewScreenDirector.OnGameStateChange += GameStateChangedEvent;
    }


    void GameStateChangedEvent(GameState1 currentState)
    {
        if(currentState == GameState1.Main)
        {
            SetUIToMainScreen();
        }
        else if (currentState == GameState1.Options)
        {
            SetUIToOptionsScreen();
        }
        else if (currentState == GameState1.Phone)
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


