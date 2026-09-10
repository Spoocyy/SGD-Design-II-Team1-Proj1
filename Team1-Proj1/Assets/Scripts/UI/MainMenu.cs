using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void CreditsMenu()
    {
        SceneManager.LoadSceneAsync("Credits");
        Time.timeScale = 1f;
    }

    public void BackMainMenu()
    {
        SceneManager.LoadSceneAsync("MainMenu");
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }



    public void PlayGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadSceneAsync("Cut Scene");
    }

    public void HelpMenu()
    {
        SceneManager.LoadSceneAsync("Help");
        Time.timeScale = 1f;
    }
}
