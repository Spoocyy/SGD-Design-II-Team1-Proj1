using System;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class FadeTransition : MonoBehaviour
{
    public static FadeTransition instance;
    
    [SerializeField] CanvasGroup canvasGroup;
    [SerializeField] private float fadeDuration = 1f;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
        
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        StartCoroutine(FadeIn());
    }

    public IEnumerator FadeOut() => Fade(0f, 1f);
    public IEnumerator FadeIn() => Fade(1f, 0f);

    private IEnumerator Fade(float start, float end)
    {
        float elapsed = 0f;
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = start;

        while (elapsed < fadeDuration)
        {
            float dt = Mathf.Min(Time.unscaledDeltaTime, 0.05f);
            elapsed += dt;
            canvasGroup.alpha = Mathf.Lerp(start, end, elapsed / fadeDuration);
            yield return null;
        }
        
        canvasGroup.alpha = end;
        canvasGroup.blocksRaycasts = (end != 0f);
    }
}
