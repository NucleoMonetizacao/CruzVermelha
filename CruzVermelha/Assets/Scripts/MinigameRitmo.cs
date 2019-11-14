using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameRitmo : MonoBehaviour
{

    [Header("Bool")]

    private bool check;


    
    [Header("Position")]

    [SerializeField]
    private Transform seta;



    public void ButtonCheck()
    {
        if(seta.position.y >= 2.33f)
        {
            Debug.Log("Acertou Vermelho");
            return;
        }
        if (seta.position.y <= 2.32f && seta.position.y >= 1.57f)
        {
            Debug.Log("Acertou Laranja");
            return;
        }
        if (seta.position.y <= 1.56f && seta.position.y >= 0.8f)
        {
            Debug.Log("Acertou Amarelo");
            return;
        }
        if (seta.position.y <= 0.7f && seta.position.y >= 0.06f)
        {
            Debug.Log("Acertou Verde Claro");
            return;
        }
        if (seta.position.y <= 0.05f && seta.position.y >= -0.722f)
        {
            Debug.Log("Acertou Verde Escuro");
            return;
        }
        if (seta.position.y <= -0.721f && seta.position.y >= -1.48f)
        {
            Debug.Log("Acertou Azul Claro");
            return;
        }
        if (seta.position.y <= -1.49f && seta.position.y >= -2.24f)
        {
            Debug.Log("Acertou Azul Escuro");
            return;
        }
        if (seta.position.y <= -2.25f && seta.position.y >= -3f)
        {
            Debug.Log("Acertou Roxo");
            return;
        }
    }
}
