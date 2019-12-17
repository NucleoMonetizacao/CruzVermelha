using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectionDirector : MonoBehaviour
{
    [SerializeField]
    CurrentLevelReference CurrentLevelReference;
    [SerializeField]
    LevelSelectionButton[] levelSelecionButtons;

    private void Awake()
    {
        SetUnlockedLevelsByPlayerPrefs();
    }

    void SetUnlockedLevelsByPlayerPrefs()
    {
        int currentLevelIndex;

        if (PlayerPrefs.HasKey("CurrentLevelIndex"))
        {
            currentLevelIndex = PlayerPrefs.GetInt("CurrentLevelIndex");
        }
        else
        {
            currentLevelIndex = 0;
            PlayerPrefs.SetInt("CurrentLevelIndex", 0);
    
        }
        for (int i = 0; i < levelSelecionButtons.Length; i++)
        {
            if (i <= currentLevelIndex)
            {
                levelSelecionButtons[i].Initialize(false);
            }
            else
            {
                levelSelecionButtons[i].Initialize(true);
            }

        }
    }

    public void CleanPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }

    public void UnlockAllLevels()
    {
        PlayerPrefs.SetInt("CurrentLevelIndex", 5);
    }

    public void SelectLevel(Level x)
    {
        CurrentLevelReference.SetValueTo(x);
        SceneManager.LoadScene(2);

    }
}
