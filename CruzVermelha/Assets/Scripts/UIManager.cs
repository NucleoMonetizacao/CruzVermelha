using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UIManager : MonoBehaviour
{
    public GameObject painelDica;
    public GameObject painelVida;
    public GameObject paineis;
    private AdMobManager _AdMobManager;

    // Start is called before the first frame update
    void Start()
    {
        painelDica.SetActive(false);
        painelVida.SetActive(false);
        _AdMobManager = FindObjectOfType(typeof(AdMobManager)) as AdMobManager;

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DicaRecebida()
    {
        painelDica.SetActive(false);
    }

    public void ReceberReward()
    {
        painelVida.SetActive(false);
    }

    public void MostrarDica()
    {
        paineis = painelDica;
        _AdMobManager.ShowRewardedAd();
    }

    public void PropagandaVida()
    {
        paineis = painelVida;
        _AdMobManager.ShowRewardedAd();
    }

}
