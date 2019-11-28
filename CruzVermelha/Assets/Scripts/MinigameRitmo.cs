using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinigameRitmo : MonoBehaviour
{

    [Header("Variaveis")]

    private bool check;
    private float vida = 50;
    private float score;



    [Header("UI")]

    [SerializeField]
    private Text textoFeedback;
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Image barraDeVida;



    [Header("Position")]

    [SerializeField]
    private Transform seta;



    public void ButtonCheck()
    {
        if (seta.localPosition.y >= -0.1f && seta.localPosition.y <= 2.3f)
        {
            
            textoFeedback.text = "Acertou !!!";
            barraDeVida.fillAmount += 0.1f;
            score++;
            scoreText.text = "Acertos: " + score;
            return;
        }
        else 
        {
            textoFeedback.text = "Errou";
            barraDeVida.fillAmount -= 0.1f;
            score--;
            scoreText.text = "Acertos: " + score;
            return;
        }
    }
}

