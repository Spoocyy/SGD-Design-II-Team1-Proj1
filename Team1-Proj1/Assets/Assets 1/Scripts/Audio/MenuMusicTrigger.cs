//Erik Robertson
//9/2/2026
//SGD Design II - Project 1 - Team 1
using UnityEngine;

public class MenuMusicTrigger : MonoBehaviour
{
    [SerializeField] AudioClip menuMusic;

    private void Start()
    {
        AudioManager.instance.PlayMusic(menuMusic);
        AudioManager.instance.StopAmbience();
    }
}
