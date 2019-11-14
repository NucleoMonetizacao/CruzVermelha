using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{

    [Header("vida")]

    [SerializeField]
    private float vida;
    [SerializeField]
    private float perdeVida;



    [Header("UI")]

    [SerializeField]
    private Image barraDeVida;


    void Update()
    {
        barraDeVida.fillAmount -= perdeVida;
    }
}
