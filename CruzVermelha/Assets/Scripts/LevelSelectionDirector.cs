using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectionDirector : MonoBehaviour
{
    [SerializeField]
    CurrentLevelReference CurrentLevelReference;

    

    public void SelectLevel(Level x)
    {
        CurrentLevelReference.SetValueTo(x);
        SceneManager.LoadScene(1);

    }
}
