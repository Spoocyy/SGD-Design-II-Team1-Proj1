//Erik Robertson
//8/26/2026
//SGD Design II - Project 1 - Team 1
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallThrower : MonoBehaviour
{
    [SerializeField] Transform throwPoint;
    [SerializeField] GameObject skullPrefab;
    private GameObject currentSkull;

    [SerializeField] float throwForce = 10f;
    [SerializeField] float arcHeight = 0.3f;
    [SerializeField] private float throwDelay = 0.8f;
    [SerializeField] Transform cameraTransform;
    private Vector3 throwDirection;
    [SerializeField] AudioClip swooshSFX;
    Animator anim;


    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private void Start()
    {
        SpawnBall();
    }

    private void SpawnBall()
    {
        currentSkull = Instantiate(skullPrefab, throwPoint.position, throwPoint.rotation);
        currentSkull.transform.SetParent(throwPoint);
        currentSkull.GetComponent<Rigidbody>().isKinematic = true;
    }

    private void ThrowBall()
    {
        throwDirection = cameraTransform.forward;
        throwDirection.y = 0;
        throwDirection.Normalize();
        throwDirection += Vector3.up * arcHeight;
        throwDirection.Normalize();

        Rigidbody rb = currentSkull.GetComponent<Rigidbody>();
        FireSkull skull = currentSkull.GetComponent<FireSkull>();

        currentSkull.transform.SetParent(null);
        rb.isKinematic = false;
        skull.PrepareForThrow();
        rb.AddForce(throwDirection * throwForce, ForceMode.Impulse);
        AudioManager.instance.PlaySFX(swooshSFX);

        StartCoroutine(RespawnAfterDelay(1f));
    }

    IEnumerator RespawnAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SpawnBall();
    }

    private void OnThrowPerformed(InputAction.CallbackContext context)
    {
        anim.SetTrigger("Throw");
        StartCoroutine(ThrowAfterDelay(throwDelay));
    }

    IEnumerator ThrowAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        ThrowBall();
    }

    private void OnEnable()
    {
        PlayerMovement.input.Player.Throw.performed += OnThrowPerformed;
        PlayerMovement.input.Player.Enable();
    }

    private void OnDisable()
    {
        PlayerMovement.input.Player.Throw.performed -= OnThrowPerformed;
        PlayerMovement.input.Player.Disable();
    }


}
