//Erik Robertson
//9/1/2026
//SGD Design II - Project 1 - Team 1
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenuUI;

    private PlayerControls input;
    public static bool IsPaused {  get; private set; }

    private void Awake()
    {
        input = new PlayerControls();
        pauseMenuUI.SetActive(false);
    }

    private void OnEnable()
    {
        input.UI.Escape.performed += TogglePause;
        input.UI.Enable();
    }

    private void OnDisable()
    {
        input.UI.Escape.performed -= TogglePause;
        input.UI.Disable();
    }

    public void Resume()
    {
        SetPaused(false);
    }

    private void TogglePause(InputAction.CallbackContext context)
    {
        SetPaused(!IsPaused);
    }

    private void SetPaused(bool paused)
    {
        IsPaused = !IsPaused;
        pauseMenuUI.SetActive(IsPaused);
        Time.timeScale = IsPaused ? 0f : 1f;

        if (IsPaused)
        {
            CursorController.Unlock();
            input.Player.Disable();
        }
        else
        {
            CursorController.Lock();
            input.Player.Enable();
        }
    }
}
