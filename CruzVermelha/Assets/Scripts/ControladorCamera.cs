using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorCamera : MonoBehaviour
{
    public Transform posCamera;
    public Transform[] localizacoes;
    public int indiceLocal;
    
    public float alturaCamera;
    public float eixoX;
    public float velocidadeCamera;

    // Start is called before the first frame update
    void Start()
    {
        alturaCamera = posCamera.position.y;



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
        if (indiceLocal < 4)
        {
            indiceLocal += 1;
        }

    }

    public void VoltaCaso()
    {
        if (indiceLocal > 0)
        {
            indiceLocal -= 1;
        }
    }


}
