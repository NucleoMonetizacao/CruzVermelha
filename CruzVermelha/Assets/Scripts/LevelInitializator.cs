using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using UnityEngine.UI;

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
    List<Transform> screenPoints;

    [SerializeField]
    BoolReference[] allTutorialBools;

    [SerializeField]
    Button nextScreenButton;
    [SerializeField]
    Button backScreenButton;

    [SerializeField]
    CurrentLevelReference nextLevelToUnlock;

    //[SerializeField]
    //PatientSelectionDirector patientSelectionDirector;

   



 

    private void Awake()
    {

        currentLevel = currentLevelReference.Value;

        SetScreenPoints();
        SetMusic();
        SetLevelBackground();
        InstantiateAllPatients();
        SetTutorial();

        EditorTests();
  

    }

    void SetScreenPoints()
    {
        if(currentLevel.NumberOfLocation == 1)
        {
            nextScreenButton.gameObject.SetActive(false);
            backScreenButton.gameObject.SetActive(false);
        }
        for(int i = 0; i < screenPoints.Count; i++)
        {
            if(i < currentLevel.NumberOfLocation)
            {
                screenPoints[i].gameObject.SetActive(true);
            }
            else
            {
                screenPoints[i].gameObject.SetActive(false);
                screenPoints.Remove(screenPoints[i]);
                i--;
            }
        }

       
    }

    private void SetTutorial()
    {
        if (currentLevel.IsTutorial)
        {
            foreach (TutorialRootInState x in FindObjectsOfType<TutorialRootInState>())
            {
                x.gameObject.SetActive(true);
            }
            foreach(BoolReference x in allTutorialBools)
            {
                x.value = false;
            }
        }
        else
        {
            foreach (TutorialRootInState x in FindObjectsOfType<TutorialRootInState>())
            {
                x.gameObject.SetActive(false);
            }
        }
    }

    private void EditorTests()
    {
#if UNITY_EDITOR
        CheckIfSumOfCaseChancesInLevelIsEqualToOne();
        CheckIfEnoughScreenPointsForNumberOfPatients();
#endif
    }

    private void SetLevelBackground()
    {
        backgroundRenderer.sprite = currentLevel.BackgroundImage;
        backgroundRenderer.transform.position += currentLevel.AddToBackgroundPosition;
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
            InstantiatePatient(caseTemplate, screenPoints[i]);
            
        }
    }

    private void InstantiatePatient(Case caseTemplate, Transform screenPoint)
    {
        Patient newPatient = Instantiate(GetRandomPatientPrefabFromCurrentLevel(), screenPoint.position, Quaternion.identity).GetComponent<Patient>();
        newPatient.Initialize(caseTemplate, screenPoint);
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

    private GameObject GetRandomPatientPrefabFromCurrentLevel()
    {
        float randomNumber = UnityEngine.Random.value;

        float currentOdds = 0f;

        for (int i = 0; i < currentLevel.PossiblePatients.Length; i++)
        {

            if (randomNumber <= currentLevel.PossiblePatients[i].ChanceToAppear + currentOdds)
            {
                return currentLevel.PossiblePatients[i].PatientPrefab;
            }
            currentOdds += currentLevel.PossiblePatients[i].ChanceToAppear;
        }

        Debug.LogError("Combined chances for patients in level isn't equal to 1");
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
