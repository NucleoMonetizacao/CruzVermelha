﻿using System.Collections;
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
    [SerializeField]
    UnityEvent WrongChoiceUnityEvent;

    


    // Start is called before the first frame update
    void Start()
    {
        playerPosicaoInicial = player.transform.position ;
    }

    public void StartMinigame()
    {
        player.transform.position = playerPosicaoInicial;
    }


    public void DragPlayer()
    {

        player.transform.position = Input.mousePosition;
    }

    public void DropPlayer()
    {
        StopCoroutine("LimpaRespostaC");
        float Distance = Vector3.Distance(player.transform.localPosition, pia.transform.localPosition);
        if(Distance<50)
        {
            player.transform.localPosition = pia.transform.localPosition;
            txtResultadoMiniGame.text = "Você tratou corretamente a queimadura";
            if (currentPatientReference.Value.PatientCase.burnInLeftHand)
            {
                SucessUnityEvent.Invoke();
            }
            else
            {
                WrongChoiceUnityEvent.Invoke();
            }

        }
        else
        {
            player.transform.position = playerPosicaoInicial;
            txtResultadoMiniGame.text = "Este não é o local correto para tratar uma queimadura";
            StartCoroutine("LimpaRespostaC");
        }
    }

    public void HealBurn()
    {
        Case x = currentPatientReference.Value.PatientCase;
        if(x.burnInLeftHand)
        {
            x.isHealed = true;
            x.burnInLeftHand = false;
            x.burn = false;
        }
    }

    IEnumerator LimpaRespostaC()
    {
        yield return new WaitForSeconds(2);
        LimpaResposta();
    }

    private void LimpaResposta()
    {
        txtResultadoMiniGame.text = " ";
    }


}
