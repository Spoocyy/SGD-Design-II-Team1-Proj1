//Erik Robertson
//9/1/2026
//SGD Design II - Project 1 - Team 1
using UnityEngine;

public class CursorController : MonoBehaviour
{
    private void Awake()
    {
        Lock();
    }

    public static void Lock()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public static void Unlock()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
