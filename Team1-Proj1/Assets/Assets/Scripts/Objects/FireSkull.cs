//Erik Robertson
//9/1/2026
//SGD Design II - Project 1 - Team 1
using UnityEngine;

public class FireSkull : MonoBehaviour
{
    [SerializeField] int damageAmount = 15;
    [SerializeField] float damageCooldown = 1f;

    [SerializeField] LayerMask groundLayer;

    [SerializeField] float lifetimeAfterLanding = 10f;

    private Rigidbody rb;
    private bool isHeld = true;
    private bool isGrounded = false;
    private float lastDamageTime = -999f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void PrepareForThrow()
    {
        if(PauseMenu.IsPaused) return;
        isHeld = false;
        isGrounded = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isHeld) { return; }

        if(!isGrounded && IsInLayerMask(collision.gameObject.layer, groundLayer))
        {
            Land();
            return;
        }

        if (isGrounded && collision.gameObject.TryGetComponent<PlayerHealth>(out var health))
        {
            TryDamage(health);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (isHeld || !isGrounded) { return; }

        if (isGrounded && collision.gameObject.TryGetComponent<PlayerHealth>(out var health))
        {
            TryDamage(health);
        }
    }

    private void Land()
    {
        isGrounded = true;
        rb.linearVelocity = Vector3.zero;
        rb.isKinematic = true;

        CancelInvoke(nameof(SelfDestruct));
        Invoke(nameof(SelfDestruct), lifetimeAfterLanding);
    }

    private void SelfDestruct()
    {
        if(this != null) Destroy(gameObject);
    }

    private void TryDamage(PlayerHealth health)
    {
        if(Time.time - lastDamageTime < damageCooldown) { return; }

        lastDamageTime = Time.time;

        health.TakeDamage(damageAmount);
    }

    private bool IsInLayerMask(int layer, LayerMask mask) => (mask.value & (1 << layer)) != 0;
}
