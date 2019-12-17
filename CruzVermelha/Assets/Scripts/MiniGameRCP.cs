using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniGameRCP : MonoBehaviour
{
    [Header("Parametros cursor")]
    [SerializeField]
    private float valorBarra;

    [SerializeField]
    private float valorCursor;

    [SerializeField]
    private bool limiteAltura;

    //[SerializeField]
    public bool acertou1;
    //[SerializeField]
    public bool acertou2;
    //[SerializeField]
    public bool acertou3;

    [SerializeField]
    private GameObject cursor;

    [Header("UI")]

    [SerializeField]
    private Text textoFeedback;

    [SerializeField]
    private Text scoreText;

    [SerializeField]
    private Image barraDeVida;

    private float score;


    // Start is called before the first frame update
    void Start()
    {
        valorCursor = -2.95f;
    }

    // Update is called once per frame
    void Update()
    {
        ControleCursor();
        
    }

    public void ControleCursor()
    {
        cursor.transform.localPosition = new Vector3(cursor.transform.localPosition.x, valorCursor, cursor.transform.localPosition.z);

        if (limiteAltura == false)
        {
            valorBarra += 1;
            valorCursor += 0.08f;
        }
        else if (limiteAltura == true)
        {
            valorBarra -= 1;
            valorCursor -= 0.08f;
        }

        if (valorBarra == 75 || valorBarra == 0)
        {
            limiteAltura = !limiteAltura;
        }

    }

    public void ComandoMassagem()
    {
        if (valorCursor >= 0.07f && valorCursor <= 0.79f)
        {
            textoFeedback.text = "Acertou !!!";
            barraDeVida.fillAmount += 0.1f;
            score++;
            scoreText.text = "Acertos: " + score;
            return;
        }
        else if (valorCursor >= 0.791f && valorCursor <= 1.56f)
        {
            textoFeedback.text = "Acertou !!!";
            barraDeVida.fillAmount += 0.05f;
            score++;
            scoreText.text = "Acertos: " + score;
            return;
        }
        else if (valorCursor >= 1.561f && valorCursor <= 2.31f)
        {
            textoFeedback.text = "Acertou !!!";
            barraDeVida.fillAmount += 0.025f;
            score++;
            scoreText.text = "Acertos: " + score;
            return;
        }
        else
        {
            textoFeedback.text = "Errou !!!";
            barraDeVida.fillAmount -= 0.1f;
            
            return;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Acertou1"))
        {
            acertou1 = true;
        }
        else if (collision.CompareTag("Acertou2"))
        {
            acertou2 = true;
        }
        else if (collision.CompareTag("Acertou3"))
        {
            acertou3 = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Acertou1"))
        {
            acertou1 = false;
        }
        else if (collision.CompareTag("Acertou2"))
        {
            acertou2 = false;
        }
        else if (collision.CompareTag("Acertou3"))
        {
            acertou3 = false;
        }
    }
}