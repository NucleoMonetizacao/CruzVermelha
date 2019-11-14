using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ScreenDirector : MonoBehaviour
{
    Patient currentPatient;
    public Patient CurrentPatient { get => currentPatient; }

    [SerializeField]
    GameState currentGameState;

    public event Action<GameState> OnGameStateChange = delegate { };

    void Start()
    {
        SetGameState(GameState.Main);
        currentPatient = FindObjectOfType<Patient>(); //placeholder
        
    }


    public void SetGameState(GameState newState)
    {
        currentGameState = newState;
        OnGameStateChange(currentGameState);
    }

    public void SetGameStateToMainScreen()
    {
        SetGameState(GameState.Main);
    }

    public void SetGameStateToOptionsScreen()
    {
        SetGameState(GameState.Options);
    }

    public void SetGameStateToPhoneScreen()
    {
        SetGameState(GameState.Phone);
    }

    public void TogglePhoneScreenGameState()
    {
        if (currentGameState == GameState.Phone)
        {
            SetGameState(GameState.Main);
        }
        else
        {
            SetGameState(GameState.Phone);
        }
    }
}

public enum GameState
{
    Main, Phone, Options
}
