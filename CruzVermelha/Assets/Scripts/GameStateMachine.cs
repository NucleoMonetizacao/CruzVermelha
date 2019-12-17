using System.Collections.Generic;
using UnityEngine;
using System;

public class GameStateMachine : MonoBehaviour
{
    [SerializeField]
    GameStateEnum startingState;

    GameStateEnum currentState;

    Dictionary<GameStateEnum, StateInMachine> stateInMachineByGameStateEnum;

    [SerializeField]
    StateInMachine[] statesInMachine;


    void Awake()
    {
        SetGameStateEnumDictionary();
    }



    void Start()
    {
        
        foreach (StateInMachine x in statesInMachine)
        {
            x.Exit();
        }
        
        if (startingState)
        {
           
            currentState = startingState;
            stateInMachineByGameStateEnum[startingState].Enter();
        }
    }

    void SetGameStateEnumDictionary()
    {
        stateInMachineByGameStateEnum = new Dictionary<GameStateEnum, StateInMachine>();
        foreach (StateInMachine x in statesInMachine)
        {
            stateInMachineByGameStateEnum.Add(x.gameStateEnum, x);
        }
    }

    public void SetState(GameStateEnum newState)
    {
        
        if (currentState)
        {
            stateInMachineByGameStateEnum[currentState].Exit();
        }
    
        stateInMachineByGameStateEnum[newState].Enter();
        currentState = newState;

    }

    [Serializable]
    public class StateInMachine
    {
#if UNITY_EDITOR
        public string gameStateName;
#endif
        public GameStateEnum gameStateEnum;
        public GameState gameState;

        public void Enter()
        {
            gameState.StateEnter();
            gameState.gameObject.SetActive(true);
            
        }

        public void Exit()
        {
            gameState.gameObject.SetActive(false);
            gameState.StateExit();
            
            
        }
    }
}
