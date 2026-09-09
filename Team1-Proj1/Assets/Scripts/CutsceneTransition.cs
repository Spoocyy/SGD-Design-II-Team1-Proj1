//Erik Robertson
//9/1/2026
//SGD Design II - Project 1 - Team 1
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneTransition : MonoBehaviour
{
    [SerializeField] float cutsceneDuration = 25f;
    [SerializeField] string nextScene = "Level 1";

    private void Start()
    {
        StartCoroutine(WaitAndLoadScene());
    }

    IEnumerator WaitAndLoadScene()
    {
        yield return new WaitForSeconds(cutsceneDuration);
        yield return FadeTransition.instance.FadeOut();
        
        AsyncOperation operation = SceneManager.LoadSceneAsync(nextScene);
        while (!operation.isDone)
        {
            yield return null;
        }
    }
}
