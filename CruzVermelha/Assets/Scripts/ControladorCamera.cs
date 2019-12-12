using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ControladorCamera : MonoBehaviour
{
    public Transform posCamera;
    public List<Transform> localizacoes;
    public int indiceLocal;
    
    public float alturaCamera;
    public float eixoX;
    public float velocidadeCamera;
    Dictionary<Transform, Patient> patientByScreenPoint = new Dictionary<Transform, Patient>();
    [SerializeField]
    private CurrentPatientReference currentPatientReference;

    [SerializeField]
    Button botaoProximo;
    [SerializeField]
    Button botaoVolta;
    


    void Start()
    {
    
        RemoverLocalizacoesInativas();
        alturaCamera = posCamera.position.y;
        Transform firstLocationTransform = localizacoes[0];
        localizacoes = localizacoes.OrderBy(x => x.position.x).ToList();
        indiceLocal = localizacoes.IndexOf(firstLocationTransform);

        CreatePatientByScreenPointDictionary();
        SetCurrentPatientReference();



    }

    void CreatePatientByScreenPointDictionary()
    {
        Patient[] patientsInScene = FindObjectsOfType<Patient>();
        foreach(Patient y in patientsInScene)
        {
            patientByScreenPoint.Add(y.currentScreenPoint, y);
        }
    }

    void RemoverLocalizacoesInativas()
    {
        for (int i = localizacoes.Count-1; i >= 0; i--)
        {
            if (!localizacoes[i].gameObject.activeSelf)
            {
                localizacoes.Remove(localizacoes[i]);
            }
        }
    }




    void Update()
    {
        eixoX = localizacoes[indiceLocal].transform.position.x;
        MoverCamera();
    }

    public void MoverCamera()
    {
        Vector3 posicaoDestinoCamera = new Vector3(eixoX, alturaCamera, -10);
        posCamera.transform.position = Vector3.Lerp(posCamera.transform.position, posicaoDestinoCamera, velocidadeCamera * Time.deltaTime);
    }

    public void ProximoCaso()
    {
        if (indiceLocal < localizacoes.Count- 1)
        {
            indiceLocal += 1;
            SetCurrentPatientReference();
            //botaoVolta.interactable = true;
            botaoVolta.image.enabled = true;
            if (indiceLocal == localizacoes.Count - 1)
            {
                //botaoProximo.interactable = false;
                botaoProximo.image.enabled = false;
                
            }
            else
            {
                botaoProximo.image.enabled = true;
                //botaoProximo.interactable = true;
            }

        }

    }

    private void SetCurrentPatientReference()
    {
        if (patientByScreenPoint.ContainsKey(localizacoes[indiceLocal]))
        {
            currentPatientReference.SetValueTo(patientByScreenPoint[localizacoes[indiceLocal]]);
        }
        else
        {
            currentPatientReference.SetValueTo(null);
        }
    }

    public void VoltaCaso()
    {
        if (indiceLocal > 0)
        {
            indiceLocal -= 1;
            SetCurrentPatientReference();
            botaoProximo.image.enabled = true;
            //botaoProximo.interactable = true;
            if(indiceLocal == 0)
            {
                //botaoVolta.interactable = false;
                botaoVolta.image.enabled = false;
            }
            else
            {
                //botaoVolta.interactable = true;
                botaoVolta.image.enabled = true;
            }
        }
    }


}
