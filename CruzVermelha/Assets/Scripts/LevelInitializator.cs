using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class LevelInitializator : MonoBehaviour
{
    [SerializeField]
    CurrentLevelReference currentLevelReference;
    [SerializeField]
    CurrentPatientReference currentPatientReference;
    Level currentLevel;



    [SerializeField]
    SpriteRenderer backgroundRenderer;
    [SerializeField]
    AudioSource musicAudioSource;

    [SerializeField]
    GameObject patientPrefab;

    [SerializeField]
    List<Transform> screenPoints;

    //[SerializeField]
    //PatientSelectionDirector patientSelectionDirector;

   



 

    private void Awake()
    {

        currentLevel = currentLevelReference.Value;
        patientPrefab = currentLevel.patientPrefab;

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
        backgroundRenderer.sprite = currentLevel.BackgroundImage;
    }

    private void SetMusic()
    {
        musicAudioSource.clip = currentLevel.MusicClip;
        musicAudioSource.Play();
    }

    private void InstantiateAllPatients()
    {
        screenPoints = screenPoints.OrderBy(i => UnityEngine.Random.value).ToList();
        for (int i = 0; i < currentLevel.NumberOfPatients; i++)
        {
            Case caseTemplate = GetRandomCaseFromCurrentLevel();
            InstantiatePatient(caseTemplate, screenPoints[i].position);
            
        }
    }

    private void InstantiatePatient(Case caseTemplate, Vector3 screenPointPosition)
    {
        Patient newPatient = Instantiate(patientPrefab, screenPointPosition, Quaternion.identity).GetComponent<Patient>();
        newPatient.Initialize(caseTemplate);
        newPatient.gameObject.name += " " + caseTemplate.name;
        currentPatientReference.SetValueTo(newPatient.GetComponent<Patient>());

    }

    private Case GetRandomCaseFromCurrentLevel()
    {
        float randomNumber = UnityEngine.Random.value;

        float currentOdds = 0f;

        for (int i = 0; i < currentLevel.PossibleCases.Length; i++)
        {

            if (randomNumber <= currentLevel.PossibleCases[i].ChanceToAppear + currentOdds)
            {
                return currentLevel.PossibleCases[i].CaseTemplate;
            }
            currentOdds += currentLevel.PossibleCases[i].ChanceToAppear;
        }

        Debug.LogError("Combined chances for cases in level isn't equal to 1");
        return null;
    }

    void CheckIfSumOfCaseChancesInLevelIsEqualToOne()
    {
        float sum = 0f;
        foreach(Level.PossibleCase x in currentLevel.PossibleCases)
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
        if (currentLevel.NumberOfPatients > screenPoints.Count)
        {
            Debug.LogError("Not enough screenPoints for patients");
        }
    }


    }
