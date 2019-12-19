using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizerPersonagem : MonoBehaviour
{

    [SerializeField]
    bool per1, per2, per3;

    static bool existeA1, existeA2, existeB1, existeB2, existeC1, existeC2;

    [SerializeField]
    SpriteRenderer[] partes;

    [SerializeField]
    Sprite[] novasPartes1;

    [SerializeField]
    Sprite[] novasPartes2;

    void Start()
    {
        if (per1)
        {
            if (existeA1 && !existeA2)
            {
                for (int i = 0; i <= partes.Length - 1; i++)
                {
                    partes[i].sprite = novasPartes1[i];
                }
                existeA2 = true;
                return;
            }
            else if (existeA1 && existeA2)
            {
                for (int i = 0; i <= partes.Length - 1; i++)
                {
                    partes[i].sprite = novasPartes2[i];
                }
                return;
            }
            existeA1 = true;
        }
        if (per2)
        {
            if (existeB1 && !existeB2)
            {
                for (int i = 0; i <= partes.Length - 1; i++)
                {
                    partes[i].sprite = novasPartes1[i];
                }
                existeB2 = true;
                return;
            }
            else if (existeB1 && existeB2)
            {
                for (int i = 0; i <= partes.Length - 1; i++)
                {
                    partes[i].sprite = novasPartes2[i];
                }
                return;
            }
            existeB1 = true;
        }
        if (per3)
        {
            if (existeC1 && !existeC2)
            {
                for (int i = 0; i <= partes.Length - 1; i++)
                {
                    partes[i].sprite = novasPartes1[i];
                }
                existeC2 = true;
                return;
            }
            else if (existeC1 && existeC2)
            {
                for (int i = 0; i <= partes.Length - 1; i++)
                {
                    partes[i].sprite = novasPartes2[i];
                }
                return;
            }
            existeC1 = true;
        }
    }
}