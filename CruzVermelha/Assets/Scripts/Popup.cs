using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popup : MonoBehaviour
{
    [SerializeField]
    bool pauseTime;



    private void OnEnable()
    {
        if(pauseTime)
        {
            Time.timeScale = 0f;
        }
        
    }

    private void OnDisable()
    {
        if (pauseTime)
        {
            Time.timeScale = 1f;
        }
    }

    
}
