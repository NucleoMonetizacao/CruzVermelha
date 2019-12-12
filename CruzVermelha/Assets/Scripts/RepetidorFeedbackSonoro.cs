using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepetidorFeedbackSonoro : MonoBehaviour
{
 

    [SerializeField]
    int NumeroRepeticoes;

    public bool diagnosticoCompleto;
    public bool queimadura;
    public bool asfixia;
    public bool rcp;
    public float tempoLoop;


    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (diagnosticoCompleto == true)
        {
            NumeroRepeticoes = 3;
            StartCoroutine("QuantidadeRepeticoes");
        }
    }

    IEnumerator QuantidadeRepeticoes()
    {
        diagnosticoCompleto = false;        

        yield return new WaitForSeconds(tempoLoop);

        if (asfixia == true)
        {
            AudioPlayer.PlaySound(3);
        }
        else if (rcp == true)
        {

        }
        else if (queimadura == true)
        {

        }

        if (NumeroRepeticoes > 0)
        {
            StartCoroutine("QuantidadeRepeticoes");
            NumeroRepeticoes--;
        }
        else
        {
            asfixia = false;
            rcp = false;
            queimadura = false;
        }
    }

    
}
