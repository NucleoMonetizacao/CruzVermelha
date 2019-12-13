using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetasManager : MonoBehaviour
{
    private ExaminationAdditionalBehaviour _Examination;

    [SerializeField]
    GameObject[] Setas;

    
    

    // Start is called before the first frame update
    void Start()
    {
        _Examination = FindObjectOfType(typeof(ExaminationAdditionalBehaviour)) as ExaminationAdditionalBehaviour;
    }

    // Update is called once per frame
  
    public void AtivarSetaDiagnostico(int idSetas)
    {
        if (_Examination.AtivaSeta == true)
        {
            Setas[idSetas].SetActive(true);
        }
    }

    public void DesativarSeta(int idSetas)
    {
        Setas[idSetas].SetActive(false);
    }

    public void AtivarSetaGeral(int idSetas)
    {
        Setas[idSetas].SetActive(true);
    }

    public void AtivarSetaDelay(int idSetas)
    {
        StartCoroutine("DelaySeta");
        
    }

    IEnumerator DelaySeta()
    {
        yield return new WaitForSeconds(3);
        Setas[2].SetActive(true);

    }
}
