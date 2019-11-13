using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class LevelInitializator : MonoBehaviour
{
    [SerializeField]
    CurrentLevelReference CurrentLevelReference;
    Level CurrentLevel;

    [SerializeField]
    SpriteRenderer backgroundRenderer;
    [SerializeField]
    AudioSource musicAudioSource;

    [SerializeField]
    GameObject patientPrefab;

    [SerializeField]
    List<Transform> screenPoints;

    [SerializeField]
    PatientSelectionDirector patientSelectionDirector;

   



 

    private void Awake()
    {

        CurrentLevel = CurrentLevelReference.Value;
        patientPrefab = CurrentLevel.patientPrefab;

        SetMusic();
        SetLevelBackground();
        InstantiateAllPatients();
        
        AudioPlayer.PlaySound(0);

#if UNITY_EDITOR
        CheckIfSumOfCaseChancesInLevelIsEqualToOne();
        CheckIfEnoughScreenPointsForNumberOfPatients();
#endif
    }

    private void SetLevelBackground()
    {
        backgroundRenderer.sprite = CurrentLevel.BackgroundImage;
    }

    private void SetMusic()
    {
        musicAudioSource.clip = CurrentLevel.MusicClip;
        musicAudioSource.Play();
    }

    private void InstantiateAllPatients()
    {
        screenPoints = screenPoints.OrderBy(i => UnityEngine.Random.value).ToList();
        for (int i = 0; i < CurrentLevel.NumberOfPatients; i++)
        {
            Case caseTemplate = GetRandomCaseFromCurrentLevel();
            InstantiatePatient(caseTemplate, screenPoints[i].position);
        }
    }

    private void InstantiatePatient(Case caseTemplate, Vector3 screenPointPosition)
    {
        Patient newPatient = Instantiate(patientPrefab, screenPointPosition, Quaternion.identity).GetComponent<Patient>();
        newPatient.Initialize(caseTemplate);
        patientSelectionDirector.NewPatientInstantiated(newPatient);
        newPatient.gameObject.name += " " + caseTemplate.name;

    }

    private Case GetRandomCaseFromCurrentLevel()
    {
        float randomNumber = UnityEngine.Random.value;

        float currentOdds = 0f;

        for (int i = 0; i < CurrentLevel.PossibleCases.Length; i++)
        {

            if (randomNumber <= CurrentLevel.PossibleCases[i].ChanceToAppear + currentOdds)
            {
                return CurrentLevel.PossibleCases[i].CaseTemplate;
            }
            currentOdds += CurrentLevel.PossibleCases[i].ChanceToAppear;
        }

        Debug.LogError("Combined chances for cases in level isn't equal to 1");
        return null;
    }

    void CheckIfSumOfCaseChancesInLevelIsEqualToOne()
    {
        float sum = 0f;
        foreach(Level.PossibleCase x in CurrentLevel.PossibleCases)
        {
            sum += x.ChanceToAppear;
        }
        if(sum != 1f)
        {
            Debug.LogError("Combined chances for cases in level isn't equal to 1");
        }
    }

    void CheckIfEnoughScreenPointsForNumberOfPatients()
    {
        if (CurrentLevel.NumberOfPatients > screenPoints.Count)
        {
            Debug.LogError("Not enough screenPoints for patients");
        }
    }


    }
