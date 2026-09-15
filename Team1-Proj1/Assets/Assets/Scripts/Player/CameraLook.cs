//Erik Robertson
//8/31/2026
//SGD Design II - Project 1 - Team 1
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    [SerializeField] Transform playerBody;
    [SerializeField] float sensitivity = 0.1f;
    [SerializeField] float minPitch = -80f; 
    [SerializeField] float maxPitch = 80f; 

    private PlayerControls input;
    private Vector2 lookInput;
    private float pitch;

    private void Awake()
    {
        input = new PlayerControls();
        input.Player.Look.performed += ctx => lookInput = ctx.ReadValue<Vector2>();
        input.Player.Look.canceled += ctx => lookInput = Vector2.zero;
    }

    private void LateUpdate()
    {
        if(PauseMenu.IsPaused) return;

        float yaw = lookInput.x * sensitivity;
        pitch -= lookInput.y * sensitivity;
        pitch = Mathf.Clamp(pitch, minPitch, maxPitch);

        playerBody.Rotate(Vector3.up * yaw);
        transform.localRotation = Quaternion.Euler(pitch, 0f, 0f);
    }

    private void OnEnable()
    {
        input.Enable();
    }

    private void OnDisable()
    {
        input.Disable();
    }
}
