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

    private float defaultFillAmount;



    [Header("UI")]

    [SerializeField]
    private Image barraDeVida;

    private void Start()
    {
        defaultFillAmount = barraDeVida.fillAmount;
    }

    public void DefaultFillAmount()
    {
        barraDeVida.fillAmount = defaultFillAmount;
    }

    void Update()
    {
        barraDeVida.fillAmount -= perdeVida;
    }
}
