﻿using System.Collections;
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
        if(seta.position.y >= 2.33f)
        {
            textoFeedback.text = "Acertou !!!";
            barraDeVida.fillAmount += 0.1f;
            score++;
            scoreText.text = "Acertos: " + score;
            return;
        }
        if (seta.position.y <= 2.32f)
        {
            textoFeedback.text = "Errou";
            barraDeVida.fillAmount -= 0.1f;
            score--;
            scoreText.text = "Acertos: " + score;
            return;
        }
    }
}

