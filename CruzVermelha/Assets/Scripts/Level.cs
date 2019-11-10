using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Level")]
public class Level : ScriptableObject
{
    [SerializeField]
    Sprite backgroundImage;
    public Sprite BackgroundImage { get => backgroundImage; }

    [SerializeField]
    AudioClip musicClip;
    public AudioClip MusicClip { get => musicClip; }



    [Space]
    [SerializeField]
    int numberOfPatients;
    public int NumberOfPatients { get => numberOfPatients; }

    [SerializeField]
    PossibleCase[] possibleCases;
    public PossibleCase[] PossibleCases { get => possibleCases; }










    [System.Serializable]
    public class PossibleCase
    {
        [SerializeField]
        Case caseTemplate;
        public Case CaseTemplate { get => caseTemplate; }

        
        [SerializeField] [Range(0, 1)]
        float chanceToAppear;
        public float ChanceToAppear { get => chanceToAppear; }


    }
}
