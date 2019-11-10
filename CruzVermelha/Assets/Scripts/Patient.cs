using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patient : MonoBehaviour
{
    Case PatientCase;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(0.5f);
        if(PatientCase == null)
        {
            Debug.LogError("Patient was not initialized");
        }
    }

    public void Initialize(Case caseTemplate)
    {
        PatientCase = CreateACopyOfCase(caseTemplate);
    }

    
    Case CreateACopyOfCase(Case caseToCopy)
    {
        //Cria uma cópia do ScriptableObject Case
        //Para que modificações nas variaveis do Case não modifiquem
        //O template do case
        return Instantiate(caseToCopy);
        
    }

}
