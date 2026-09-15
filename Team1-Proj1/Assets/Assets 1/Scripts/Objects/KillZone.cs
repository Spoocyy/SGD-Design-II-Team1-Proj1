//Erik Robertson
//9/1/2026
//SGD Design II - Project 1 - Team 1
using UnityEngine;

public class KillZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<PlayerHealth>(out var health))
        {
            health.Kill();
        }
    }
}
