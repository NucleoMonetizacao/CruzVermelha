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

    [SerializeField]
    Button botaoProximo;
    [SerializeField]
    Button botaoVolta;
    

    // Start is called before the first frame update
    void Start()
    {
    
        RemoverLocalizacoesInativas();
        alturaCamera = posCamera.position.y;
        Transform firstLocationTransform = localizacoes[0];
        localizacoes = localizacoes.OrderBy(x => x.position.x).ToList();
        indiceLocal = localizacoes.IndexOf(firstLocationTransform);
        



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

    // Update is called once per frame
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
            botaoVolta.interactable = true;
            if (indiceLocal == localizacoes.Count - 1)
            {
                botaoProximo.interactable = false;
                
            }
            else
            {
                botaoProximo.interactable = true;
            }

        }

    }

    public void VoltaCaso()
    {
        if (indiceLocal > 0)
        {
            indiceLocal -= 1;
            botaoProximo.interactable = true;
            if(indiceLocal == 0)
            {
                botaoVolta.interactable = false;
            }
            else
            {
                botaoVolta.interactable = true;
            }
        }
    }


}
