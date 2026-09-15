//Erik Robertson
//9/2/2026
//SGD Design II - Project 1 - Team 1
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField] AudioSource sfxSource;
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource ambienceSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }

    public void PlayMusic(AudioClip clip)
    {
        if(musicSource.clip == clip && musicSource.isPlaying) { return; }

        musicSource.clip = clip;
        musicSource.loop = true;
        musicSource.Play();
    }

    public void PlayAmbience(AudioClip clip)
    {
        if (ambienceSource.clip == clip && musicSource.isPlaying) { return; }
        ambienceSource.clip = clip;
        ambienceSource.loop = true;
        ambienceSource.Play();
    }

    public void StopMusic() => musicSource.Stop();
    public void StopAmbience() => ambienceSource.Stop();
}
