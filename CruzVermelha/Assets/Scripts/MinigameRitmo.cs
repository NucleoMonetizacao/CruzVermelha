using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinigameRitmo : MonoBehaviour
{

    [Header("Bool")]

    private bool check;



    [Header("Texto")]

    [SerializeField]
    private Text textoFeedback;


    
    [Header("Position")]

    [SerializeField]
    private Transform seta;



    public void ButtonCheck()
    {
        if(seta.position.y >= 2.33f)
        {
            textoFeedback.text = "Acertou Vermelho";
            return;
        }
        if (seta.position.y <= 2.32f && seta.position.y >= 1.57f)
        {
            textoFeedback.text = "Acertou Laranja";
            return;
        }
        if (seta.position.y <= 1.56f && seta.position.y >= 0.8f)
        {
            textoFeedback.text = "Acertou Amarelo";
            return;
        }
        if (seta.position.y <= 0.7f && seta.position.y >= 0.06f)
        {
            textoFeedback.text = "Acertou Verde Claro";
            return;
        }
        if (seta.position.y <= 0.05f && seta.position.y >= -0.722f)
        {
            textoFeedback.text = "Acertou Verde Escuro";
            return;
        }
        if (seta.position.y <= -0.721f && seta.position.y >= -1.48f)
        {
            textoFeedback.text = "Acertou Azul Claro";
            return;
        }
        if (seta.position.y <= -1.49f && seta.position.y >= -2.24f)
        {
            textoFeedback.text = "Acertou Azul Escuro";
            return;
        }
        if (seta.position.y <= -2.25f && seta.position.y >= -3f)
        {
            textoFeedback.text = "Acertou Roxo";
            return;
        }
    }
}
