using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Teleport : MonoBehaviour
{
    public Transform player, destination;
    public GameObject Player;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player.SetActive(false);
            player.position = destination.position;
            Player.SetActive(true);

        }
    }
}
