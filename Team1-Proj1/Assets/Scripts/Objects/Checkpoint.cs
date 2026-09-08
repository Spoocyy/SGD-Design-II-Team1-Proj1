using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] Transform newRespawnPoint;

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
            }
        }
    }
}
