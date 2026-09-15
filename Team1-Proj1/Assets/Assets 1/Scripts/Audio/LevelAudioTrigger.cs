//Erik Robertson
//9/2/2026
//SGD Design II - Project 1 - Team 1
using UnityEngine;

public class LevelAudioTrigger : MonoBehaviour
{
    [SerializeField] AudioClip levelAmbience;

    private void Start()
    {
        AudioManager.instance.PlayAmbience(levelAmbience);
        AudioManager.instance.StopMusic();
    }
}
