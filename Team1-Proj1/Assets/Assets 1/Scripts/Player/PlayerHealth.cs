//Erik Robertson
//9/1/2026
//SGD Design II - Project 1 - Team 1
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int maxHealth = 100;
    [SerializeField] HealthUI healthUI;
    [SerializeField] AudioClip hurtSFX;
    [SerializeField] Animator anim;

    public int CurrentHealth { get; private set; }

    private void Awake()
    {
        CurrentHealth = maxHealth;
    }

    private void Start()
    {
        healthUI.UpdateBar(CurrentHealth, maxHealth);
    }

    public void TakeDamage(int amount)
    {
        PlayerRespawn playerRespawn = GetComponent<PlayerRespawn>();
        PlayerMovement playerMovement = GetComponent<PlayerMovement>();

        if (CurrentHealth <= 0)
        {
            return;
        }

        CurrentHealth = Mathf.Max(CurrentHealth - amount, 0);
        healthUI.UpdateBar(CurrentHealth, maxHealth);
        AudioManager.instance.PlaySFX(hurtSFX);

        if (CurrentHealth == 0)
        {
            anim.SetTrigger("Death");
            playerMovement.enabled = false;
            playerRespawn.HandleDeath();
        }
        else
        {
            anim.SetTrigger("Hurt");
        }
    }

    public void Kill()
    {
        PlayerRespawn playerRespawn = GetComponent<PlayerRespawn>();
        PlayerMovement playerMovement = GetComponent<PlayerMovement>();

        if (CurrentHealth <= 0) { return; }

        CurrentHealth = 0;
        healthUI.UpdateBar(CurrentHealth, maxHealth);
        AudioManager.instance.PlaySFX(hurtSFX);
        anim.SetTrigger("Death");
        playerMovement.enabled = false;
        playerRespawn.HandleDeath();
    }

    public void ResetHealth()
    {
        PlayerMovement playerMovement = GetComponent<PlayerMovement>();
        CurrentHealth = maxHealth;
        healthUI.UpdateBar(CurrentHealth, maxHealth);
        playerMovement.enabled = true;
    }
}
