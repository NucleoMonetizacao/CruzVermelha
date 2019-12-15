using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField]
    CurrentLevelReference currentLevelReference;

    public void LoadLevel()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadLevelSelection()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void UnlockNextLevel()
    {
        int currentLevelIndex = PlayerPrefs.GetInt("CurrentLevelIndex");
        if (currentLevelIndex == currentLevelReference.Value.LevelIndex)
        {
            PlayerPrefs.SetInt("CurrentLevelIndex", currentLevelIndex + 1);
        }
    }
}
