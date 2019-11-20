using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniGameQueimadura : MonoBehaviour
{
    public GameObject player, forno, geladeira, pia, microondas;

   public  Vector2 playerPosicaoInicial;

    public Text txtResultadoMiniGame; 

    // Start is called before the first frame update
    void Start()
    {
        playerPosicaoInicial = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DragPlayer()
    {
        player.transform.position = Input.mousePosition;
    }

    public void DropPlayer()
    {
        float Distance = Vector3.Distance(player.transform.position, pia.transform.position);
        if(Distance<50)
        {
            player.transform.position = pia.transform.position;
            txtResultadoMiniGame.text = "Você tratou corretamente a queimadura";

        }
        else
        {
            player.transform.position = playerPosicaoInicial;
            txtResultadoMiniGame.text = "Este não é o local correto para tratar uma queimadura";
            StartCoroutine("LimpaResposta");
        }
    }

    IEnumerator LimpaResposta()
    {
        yield return new WaitForSeconds(2);
        txtResultadoMiniGame.text = " ";
    }


}
