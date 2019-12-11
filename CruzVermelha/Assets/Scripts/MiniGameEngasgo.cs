using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MiniGameEngasgo : MonoBehaviour
{
    [Header("Variaveis da barra e cursor")]
    public GameObject cursor;


    public float valorBarra;
    public float subtracaoBarra;
    public float adicaoBarra;

    Vector3 startingPosition;
    float defSubtracaoBarra = 0;
    float defAdicaoBarra;
    float defValorBarror;

    [Header("Variaveis resultado")]
    public Text txtResultado;

    public  event Action OnSucess = delegate { };
    public event Action OnFailure = delegate { };


    private void Start()
    {
        startingPosition = transform.localPosition;
        defAdicaoBarra = adicaoBarra;
        defSubtracaoBarra = subtracaoBarra;
        defValorBarror = valorBarra;
       
    }

    public void SetDefaultValues()
    {
        
        transform.localPosition = startingPosition;
        subtracaoBarra = defSubtracaoBarra;
        adicaoBarra = defAdicaoBarra;
        valorBarra = defValorBarror;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale > 0)
        ControleCursor();
    }

    public void AcaoEngasgo()
    {
        valorBarra += adicaoBarra;
    }

    public void ControleCursor()
    {
        cursor.transform.position = new Vector3(cursor.transform.position.x, valorBarra, cursor.transform.position.z);

        valorBarra -= subtracaoBarra;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("FimEngasgo"))
        {
            txtResultado.text = "Você conseguiu!";
            subtracaoBarra = 0;
            adicaoBarra = 0;
            OnSucess();
        }
        else if (collision.CompareTag("PerdeuEngasgo"))
        {


            txtResultado.text = "O paciente morreu";
            subtracaoBarra = 0;
            adicaoBarra = 0;
            OnFailure();

        }
    }
}
