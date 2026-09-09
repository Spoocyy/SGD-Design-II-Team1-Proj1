//Erik Robertson
//9/2/2026
//SGD Design II - Project 1 - Team 1
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelTransition : MonoBehaviour
{
    public void LoadNextScene()
    {
        Time.timeScale = 1.0f;
        StartCoroutine(TransitionRoutine());
    }

    private IEnumerator TransitionRoutine()
    {
        yield return FadeTransition.instance.FadeOut();
        
        int nextIndex = SceneManager.GetActiveScene().buildIndex + 1;
        AsyncOperation operation = SceneManager.LoadSceneAsync(nextIndex);
        while (!operation.isDone)
        {
            yield return null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            LoadNextScene();
        }
    }
}
