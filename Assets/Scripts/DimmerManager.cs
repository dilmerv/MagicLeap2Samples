using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.MagicLeap;

public class DimmerUtilities : MonoBehaviour
{
    private const string GLOBAL_DIMMER_TEXT = "Global Dimmer";

    [SerializeField]
    private TextMeshProUGUI globalDimmerText;

    [SerializeField]
    private Slider globalDimmerSlider;

    private void Start()
    {
        globalDimmerSlider.value = 0;
        globalDimmerText.text = $"{GLOBAL_DIMMER_TEXT}: {0.00}";
        SetGlobalDimmerValue(0);
        globalDimmerSlider.onValueChanged.AddListener((newValue) =>
        {
            globalDimmerSlider.value = newValue;
            Logger.Instance.LogInfo($"{GLOBAL_DIMMER_TEXT} set to: {newValue:0.00}");
            globalDimmerText.text = $"{GLOBAL_DIMMER_TEXT}: {newValue:0.00}";
            SetGlobalDimmerValue(0);
        });
    }

    private void SetGlobalDimmerValue(float newValue) => MLGlobalDimmer.SetValue(newValue);
}
