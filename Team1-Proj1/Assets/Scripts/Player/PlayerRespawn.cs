//Erik Robertson
//9/1/2026
//SGD Design II - Project 1 - Team 1
using System.Collections;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    [SerializeField] Transform respawnPoint1;
    [SerializeField] float respawnDelay = 2f;

    private Transform currentRespawnPoint;

    private void Awake()
    {
        currentRespawnPoint = respawnPoint1;
    }

    public void SetRespawnPoint(Transform newPoint)
    {
        currentRespawnPoint = newPoint;
        Debug.Log("setting new point");
    }

    public void HandleDeath()
    {
        //death animation and sound effect
        Debug.Log("Handle death called");
        StartCoroutine(RespawnAfterDelay());
    }

    private IEnumerator RespawnAfterDelay()
    {
        yield return new WaitForSeconds(respawnDelay);
        Debug.Log("Respawning at: " + currentRespawnPoint.name);

        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }

        transform.position = currentRespawnPoint.position;
        transform.rotation = currentRespawnPoint.rotation;

        PlayerHealth playerHealth = GetComponent<PlayerHealth>();
        playerHealth.ResetHealth();

        PlayerMovement playerMovement = GetComponent<PlayerMovement>();
        if (playerMovement)
        {
            playerMovement.enabled = true;
        }
    }
}
