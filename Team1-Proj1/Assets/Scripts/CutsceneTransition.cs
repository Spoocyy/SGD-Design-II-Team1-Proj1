//Erik Robertson
//9/1/2026
//SGD Design II - Project 1 - Team 1
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneTransition : MonoBehaviour
{
    [SerializeField] float cutsceneDuration = 25f;

    private void Start()
    {
        StartCoroutine(WaitAndLoadScene());
    }

    IEnumerator WaitAndLoadScene()
    {
        yield return new WaitForSeconds(cutsceneDuration);
        yield return FadeTransition.instance.FadeOut();
        
        string currentScene = SceneManager.GetActiveScene().name;
        string nextScene;

        if (currentScene == "Cut Scene")
        {
            nextScene = "Level 1";
        }
        else if (currentScene == "EndCutscene")
        {
            nextScene = "MainMenu";
        }
        else
        {
            Debug.Log("No Next Scene");
            yield break;
        }
        
        AsyncOperation operation = SceneManager.LoadSceneAsync(nextScene);
        while (!operation.isDone)
        {
            yield return null;
        }
    }
}
