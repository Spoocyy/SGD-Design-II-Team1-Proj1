using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] Transform newRespawnPoint;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip drumClip;
    [SerializeField] private Animator checkpointTextAnim;

    private bool triggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (triggered) return;

        if (other.CompareTag("Player"))
        {
            PlayerRespawn playerRespawn = other.GetComponent<PlayerRespawn>();
            if (playerRespawn != null)
            {
                playerRespawn.SetRespawnPoint(newRespawnPoint);
                Debug.Log("Checkpoint works");
                triggered = true;
                
                audioSource.PlayOneShot(drumClip);
                checkpointTextAnim.SetTrigger("ShowText");
            }
        }
    }
}
