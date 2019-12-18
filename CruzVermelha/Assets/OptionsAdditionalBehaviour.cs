using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsAdditionalBehaviour : MonoBehaviour
{
    public void GoBackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(2);
    }

    public void LevelSelect()
    {
        SceneManager.LoadScene(1);
    }

    public void OpenWebSite()
    {
        Application.OpenURL("http://www.cruzvermelha.org.br/pb/");
    }

    public void OpenAppPage()
    {
        Application.OpenURL("https://play.google.com/store/apps/details?id=com.cvb.members");
    }
}
