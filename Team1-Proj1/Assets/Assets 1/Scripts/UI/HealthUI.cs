//Erik Robertson
//9/1/2026
//SGD Design II - Project 1 - Team 1
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] Slider healthBar;

    public void UpdateBar(int current, int max)
    {
        healthBar.maxValue = max;
        healthBar.value = current;
    }
}
