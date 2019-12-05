using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MiniGameQueimadura : MonoBehaviour
{
    public GameObject player, forno, geladeira, pia, microondas;

   public  Vector2 playerPosicaoInicial;
    Vector2 offset;

    public Text txtResultadoMiniGame;

    [SerializeField]
    CurrentPatientReference currentPatientReference;

    [SerializeField]
    UnityEvent SucessUnityEvent;

    


    // Start is called before the first frame update
    void Start()
    {
        playerPosicaoInicial = player.transform.position ;
    }


    public void DragPlayer()
    {

        player.transform.position = Input.mousePosition;
    }

    public void DropPlayer()
    {
        StopCoroutine("LimpaResposta");
        float Distance = Vector3.Distance(player.transform.localPosition, pia.transform.localPosition);
        if(Distance<50)
        {
            player.transform.localPosition = pia.transform.localPosition;
            txtResultadoMiniGame.text = "Você tratou corretamente a queimadura";
            SucessUnityEvent.Invoke();

        }
        else
        {
            player.transform.position = playerPosicaoInicial;
            txtResultadoMiniGame.text = "Este não é o local correto para tratar uma queimadura";
            StartCoroutine("LimpaResposta");
        }
    }

    public void HealBurn()
    {
        Case x = currentPatientReference.Value.PatientCase;
        if(x.burnInLeftHand)
        {
            x.burnInLeftHand = false;
            x.burn = false;
        }
    }

    IEnumerator LimpaResposta()
    {
        yield return new WaitForSeconds(2);
        txtResultadoMiniGame.text = " ";
    }


}
