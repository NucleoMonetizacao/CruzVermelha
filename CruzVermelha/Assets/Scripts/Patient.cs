using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Patient : MonoBehaviour
{
    Case patientCase;
    public Case PatientCase { get => patientCase; }

    public event Action<Patient> OnSelected = delegate { };

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(0.5f);
        if(patientCase == null)
        {
            Debug.LogError("Patient was not initialized");
        }
    }

    public void Initialize(Case caseTemplate)
    {
        patientCase = CreateACopyOfCase(caseTemplate);
    }

    public void Selected()
    {
        OnSelected(this);

    }

    
    Case CreateACopyOfCase(Case caseToCopy)
    {
        //Cria uma cópia do ScriptableObject Case
        //Para que modificações nas variaveis do Case não modifiquem
        //O template do case
        return Instantiate(caseToCopy);
        
    }

}
