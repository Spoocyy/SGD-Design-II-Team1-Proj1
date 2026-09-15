using UnityEngine;
using UnityEngine.UI;

public class BrightnessAdjuster : MonoBehaviour
{
    [SerializeField] Slider brightnessSlider;

    [SerializeField] float minIntensity = 0f;
    [SerializeField] float maxIntensity = 1f;

    private void Start()
    {
        brightnessSlider.minValue = minIntensity;
        brightnessSlider.maxValue = maxIntensity;

        brightnessSlider.value = RenderSettings.ambientIntensity;

        brightnessSlider.onValueChanged.AddListener(SetAmbientIntensity);
    }

    private void SetAmbientIntensity(float value)
    {
        RenderSettings.ambientIntensity = value;
    }

    private void OnDestroy()
    {
        brightnessSlider.onValueChanged.RemoveAllListeners();
    }
}
