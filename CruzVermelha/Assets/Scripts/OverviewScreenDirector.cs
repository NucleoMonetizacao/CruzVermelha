using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class OverviewScreenDirector : MonoBehaviour
{
    Patient currentPatient;
    public Patient CurrentPatient { get => currentPatient; }

    [SerializeField]
    GameState1 currentGameState;

    public event Action<GameState1> OnGameStateChange = delegate { };

    void Start()
    {
        SetGameState(GameState1.Main);
        currentPatient = FindObjectOfType<Patient>(); //placeholder
        
    }


    public void SetGameState(GameState1 newState)
    {
        currentGameState = newState;
        OnGameStateChange(currentGameState);
    }

    public void SetGameStateToMainScreen()
    {
        SetGameState(GameState1.Main);
    }

    public void SetGameStateToOptionsScreen()
    {
        SetGameState(GameState1.Options);
    }

    public void SetGameStateToPhoneScreen()
    {
        SetGameState(GameState1.Phone);
    }

    public void TogglePhoneScreenGameState()
    {
        if (currentGameState == GameState1.Phone)
        {
            SetGameState(GameState1.Main);
        }
        else
        {
            SetGameState(GameState1.Phone);
        }
    }
}

public enum GameState1
{
    Main, Phone, Options
}
