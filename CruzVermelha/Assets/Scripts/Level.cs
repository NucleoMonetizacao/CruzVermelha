using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Level")]
public class Level : ScriptableObject
{

    [SerializeField]
    int levelIndex;
    public int LevelIndex { get => levelIndex; }

    [SerializeField]
    Sprite backgroundImage;
    public Sprite BackgroundImage { get => backgroundImage; }
    [SerializeField]
    Vector3 addToBackgroundPosition;
    public Vector3 AddToBackgroundPosition { get => addToBackgroundPosition; }


    [SerializeField]
    AudioClip musicClip;
    public AudioClip MusicClip { get => musicClip; }


    [SerializeField]
    bool isTutorial = false;
    public bool IsTutorial { get => isTutorial; }

    [SerializeField]
    int numberOfLocations = 1;
    public int NumberOfLocation { get => numberOfLocations; }




    [Space]
    [SerializeField]
    int numberOfPatients;
    public int NumberOfPatients { get => numberOfPatients; }

    [SerializeField]
    PossibleCase[] possibleCases;
    public PossibleCase[] PossibleCases { get => possibleCases; }

    [SerializeField]
    PossiblePatient[] possiblePatients;
    public PossiblePatient[] PossiblePatients { get => possiblePatients; }






    [System.Serializable]
    public class PossiblePatient
    {
        [SerializeField]
        GameObject patientPrefab;
        public GameObject PatientPrefab { get => patientPrefab; }


        [SerializeField]
        [Range(0, 1)]
        float chanceToAppear;
        public float ChanceToAppear { get => chanceToAppear; }


    }

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
