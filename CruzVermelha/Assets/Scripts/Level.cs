using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Level")]
public class Level : ScriptableObject
{
    [SerializeField]
    PossibleCase[] PossibleCases;

  




    [System.Serializable]
    public class PossibleCase
    {
        [SerializeField]
        Case CaseTemplate;

        
        [SerializeField] [Range(0, 1)]
        float chanceToAppear;

        
    }
}
