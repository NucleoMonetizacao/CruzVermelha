using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameStateMachine : MonoBehaviour
{
    [SerializeField]
    StateInMachine[] statesInMachine;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [Serializable]
    public class StateInMachine
    {
#if UNITY_EDITOR
        public string gameStateName;
#endif
        public GameStateEnum gameStateEnum;
        public GameState gameState;
    }
}
