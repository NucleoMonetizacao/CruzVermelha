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

    [Header("Variaveis resultado")]
    public Text txtResultado;

    public  event Action OnSucess = delegate { };
    public event Action OnFailure = delegate { };


    

    // Update is called once per frame
    void Update()
    {
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
